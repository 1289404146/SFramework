using UnityEngine;

public class JoystickManager : MonoBehaviour
{

    public Joystick joystick;

    public Transform moveTarget;

    public float moveSpeed = 10.0f;

    // Use this for initialization

    void Start()
    {
        moveTarget = GameObject.Find("Cube").gameObject.transform;
        joystick.OnTouchMove += OnJoystickMove;

    }

    private void OnJoystickMove(JoystickData joystickData)
    {

        float moveX = Mathf.Cos(joystickData.radians) * moveSpeed *

            Time.deltaTime * joystickData.power;

        float moveZ = Mathf.Sin(joystickData.radians) * moveSpeed *

            Time.deltaTime * joystickData.power;

        moveTarget.Translate(new Vector3(moveX, 0, moveZ));

    }

}