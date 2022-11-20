using System;
using UnityEngine;

public enum PlayerAnim
{
    Idle = 0,
    Wolk,
    Run
}
public class JoystickManager : MonoBehaviour
{

    public Joystick joystick;
    public static JoystickManager Ins;

    public Transform moveTarget;
    public Animator animator;
    public GameObject bar;

    public float moveSpeed = 20.0f;
    private int syncRate = 30;

    // Use this for initialization
    private Transform localPlayerTransform;
    private PlayerMove localPlayerMove;

    private Transform remotePlayerTransform;
    private Animator remotePlayerAnim;

    private bool isSyncRemotePlayer = false;
    private Vector3 pos;
    private Vector3 rotation;
    private float forward;
    void Start()
    {
        Ins = this;
        moveTarget = GameObject.Find("Local").gameObject.transform;
        bar = GameObject.Find("Local/Canvas").gameObject;
        animator = GameObject.Find("Local/Male A").GetComponent<Animator>();
        joystick.OnTouchMove += OnJoystickMove;
        joystick.OnTouchRotate += OnTouchRotate;
        InvokeRepeating("SyncLocalPlayer", 1f, 1f / syncRate);
        Main.RequestManager.AddRequest(ActionCode.Move, new MoveRequest(RequestCode.Game, ActionCode.Move, (data) =>
       {
           string[] strs = data.Split('|');
           pos = UnityTools.ParseVector3(strs[0]);
           rotation = UnityTools.ParseVector3(strs[1]);
           forward = float.Parse(strs[2]);
           isSyncRemotePlayer = true;
       }));
        localPlayerTransform = moveTarget;
    }
    private void SyncLocalPlayer()
    {
        Main.ClientManager.SendRequest(RequestCode.Game, ActionCode.Move,
            SendRequest(localPlayerTransform.position.x, localPlayerTransform.position.y, localPlayerTransform.position.z,
            localPlayerTransform.eulerAngles.x, localPlayerTransform.eulerAngles.y, localPlayerTransform.eulerAngles.z,
            0));
        ;
    }
    private void FixedUpdate()
    {
        if (isSyncRemotePlayer)
        {
            SyncRemotePlayer();
            isSyncRemotePlayer = false;
        }
    }
    private void SyncRemotePlayer()
    {
        remotePlayerTransform.position = pos;
        remotePlayerTransform.eulerAngles = rotation;
        remotePlayerAnim.SetFloat("Forward", forward);
    }

    private string SendRequest(float x, float y, float z, float rotationX, float rotationY, float rotationZ, float forward)
    {
        string data = string.Format("{0},{1},{2}|{3},{4},{5}|{6}", x, y, z, rotationX, rotationY, rotationZ, forward);
        return data;
    }
    private void Update()
    {
        bar.transform.LookAt(bar.transform.position + (Camera.main.transform.rotation * Vector3.forward), Camera.main.transform.rotation * Vector3.up);
    }
    private void OnTouchRotate(float hor, float ver)
    {
        Vector3 direction = new Vector3(hor, 0, ver);
        moveTarget.rotation = Quaternion.Lerp(moveTarget.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);
        float res = Mathf.Max(Mathf.Abs(hor), Mathf.Abs(ver));
        forward = res;
        animator.SetInteger("PlayerAnim", 1);
    }

    private void OnJoystickMove(JoystickData joystickData)
    {

        float moveX = Mathf.Cos(joystickData.radians) * moveSpeed *

            Time.deltaTime * joystickData.power;

        float moveZ = Mathf.Sin(joystickData.radians) * moveSpeed *

            Time.deltaTime * joystickData.power;

        moveTarget.Translate(new Vector3(moveX, 0, moveZ), Space.World);

    }


    public void SetLocalPlayer(Transform localPlayerTransform, PlayerMove localPlayerMove)
    {
        this.localPlayerTransform = localPlayerTransform;
        //this.localPlayerMove = localPlayerMove;
    }
    public void SetRemotePlayer(Transform remotePlayerTransform)
    {
        this.remotePlayerTransform = remotePlayerTransform;
        this.remotePlayerAnim = remotePlayerTransform.GetComponent<Animator>();
    }
}
