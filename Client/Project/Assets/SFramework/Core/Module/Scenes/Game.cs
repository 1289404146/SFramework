using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
class Game : BaseMono, IScene
{
    private Dictionary<RoleType, RoleData> roleDataDict = new Dictionary<RoleType, RoleData>();
    private Transform rolePositions;
    public void Initilize()
    {
        Debug.Log("Game_____Initilize");
        Debug.Log("初始化游戏");
        Main.UIManager.OpenPanel<UIGameStartLogic>(UIType.UIGameStart);
        InitRoleDataDict();
    }

    private void InitRoleDataDict()
    {
        currentRoleType = Main.GameManager.RoleType;
        rolePositions = GameObject.Find("RolePositions").transform;
        roleDataDict.Add(RoleType.Blue, new RoleData(RoleType.Blue, "Player" , rolePositions.Find("Position1")));
        roleDataDict.Add(RoleType.Red, new RoleData(RoleType.Red, "Player" , rolePositions.Find("Position2")));
        SpawnRoles();
    }

    private bool isSyncRemotePlayer = false;
    private Vector3 pos;
    private Vector3 rotation;
    private float forward;

    private RoleType currentRoleType;
    private GameObject currentRoleGameObject;
    private GameObject playerSyncRequest;
    private GameObject remoteRoleGameObject;
    public void SpawnRoles()
    {
        foreach (RoleData rd in roleDataDict.Values)
        {
            GameObject go = GameObject.Instantiate(rd.RolePrefab, rd.SpawnPosition, Quaternion.identity);
            go.tag = "Player";
            if (rd.RoleType == currentRoleType)
            {
                currentRoleGameObject = go;
                currentRoleGameObject.GetComponent<PlayerInfo>().isLocal = true;
                currentRoleGameObject.name = "Local";
            }
            else
            {
                remoteRoleGameObject = go;
            }
        }
    }
    //public void InitLocolPlayer()
    //{
    //    GameObject player= Main.ResourcesManager.Load<GameObject>("Prefabs/Player");
    //    GameObject go = GameObject.Instantiate(player, new Vector3(1,1,1), Quaternion.identity);
    //    go.name = "Cube";
    //}
    public void CreateSyncRequest()
    {
        //playerSyncRequest = new GameObject("PlayerSyncRequest");
        //playerSyncRequest.AddComponent<MoveRequest>().SetLocalPlayer(currentRoleGameObject.transform, currentRoleGameObject.GetComponent<PlayerMove>())
        //    .SetRemotePlayer(remoteRoleGameObject.transform);
        //shootRequest = playerSyncRequest.AddComponent<ShootRequest>();
        //shootRequest.playerMng = this;
        //attackRequest = playerSyncRequest.AddComponent<AttackRequest>();
    }
    public void DeInitilize()
    {
        Debug.Log("Game_____DeInitilize");
        Main.UIManager.ClosePanel<UIGameStartLogic>(UIType.UIGameStart);
    }
    private UserData userData;

    public void UpdateResult(int totalCount, int winCount)
    {
        userData.TotalCount = totalCount;
        userData.WinCount = winCount;
    }
    public void SetCurrentRoleType(RoleType rt)
    {
        currentRoleType = rt;
    }
    public UserData UserData
    {
        set { userData = value; }
        get { return userData; }
    }

 

    public GameObject GetCurrentRoleGameObject()
    {
        return currentRoleGameObject;
    }
    private RoleData GetRoleData(RoleType rt)
    {
        RoleData rd = null;
        roleDataDict.TryGetValue(rt, out rd);
        return rd;
    }
    public void AddControlScript()
    {
        currentRoleGameObject.AddComponent<PlayerMove>();
        //PlayerAttack playerAttack = currentRoleGameObject.AddComponent<PlayerAttack>();
        RoleType rt = currentRoleGameObject.GetComponent<PlayerInfo>().roleType;
        RoleData rd = GetRoleData(rt);
        //playerAttack.arrowPrefab = rd.ArrowPrefab;
        //playerAttack.SetPlayerMng(this);
    }
    //public void CreateSyncRequest()
    //{
    //    playerSyncRequest = new GameObject("PlayerSyncRequest");
    //    playerSyncRequest.AddComponent<MoveRequest>().SetLocalPlayer(currentRoleGameObject.transform, currentRoleGameObject.GetComponent<PlayerMove>())
    //        .SetRemotePlayer(remoteRoleGameObject.transform);
    //    shootRequest = playerSyncRequest.AddComponent<ShootRequest>();
    //    shootRequest.playerMng = this;
    //    attackRequest = playerSyncRequest.AddComponent<AttackRequest>();
    //}
    //public void Shoot(GameObject arrowPrefab, Vector3 pos, Quaternion rotation)
    //{
    //    facade.PlayNormalSound(AudioManager.Sound_Timer);
    //    GameObject.Instantiate(arrowPrefab, pos, rotation).GetComponent<Arrow>().isLocal = true;
    //    shootRequest.SendRequest(arrowPrefab.GetComponent<Arrow>().roleType, pos, rotation.eulerAngles);
    //}
    //public void RemoteShoot(RoleType rt, Vector3 pos, Vector3 rotation)
    //{
    //    GameObject arrowPrefab = GetRoleData(rt).ArrowPrefab;
    //    Transform transform = GameObject.Instantiate(arrowPrefab).GetComponent<Transform>();
    //    transform.position = pos;
    //    transform.eulerAngles = rotation;
    //}
    //public void SendAttack(int damage)
    //{
    //    //attackRequest.SendRequest(damage);
    //}
    public void GameOver()
    {
        //private GameObject currentRoleGameObject;
        //private GameObject playerSyncRequest;
        //private GameObject remoteRoleGameObject;

        //private ShootRequest shootRequest;
        //private AttackRequest attackRequest;
        GameObject.Destroy(currentRoleGameObject);
        GameObject.Destroy(playerSyncRequest);
        GameObject.Destroy(remoteRoleGameObject);
    }
}
