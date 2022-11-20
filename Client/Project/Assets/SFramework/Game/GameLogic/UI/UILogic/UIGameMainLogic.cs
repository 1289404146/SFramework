using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UIGameMainLogic : UIBaseLogic
{

    public UIGameMainView uiView;

    public UIGameMainLogic()
    {
        uiLayer = UILayer.Default;
        uiType = UIType.UIGameMain;
    }

    private void Awake()
    {
        uiView = new UIGameMainView();
        uiView.Init(transform);
        uiView.backButton.onClick.AddListener(BackButtonClick);
        uiView.activeButton.onClick.AddListener(ActiveButton);
        uiView.StartButton.onClick.AddListener(OpenRoom);
        uiView.createRoomButton.onClick.AddListener(CreateRoomButton);
        uiView.refreshButton.onClick.AddListener(ReFreshButton);
        uiView.bagButton.onClick.AddListener(BagButton);
        uiView.friendButton.onClick.AddListener(FrientButton);
        uiView.recordButton.onClick.AddListener(RecordButton);
        uiView.chatToggle.onValueChanged.AddListener(ChatRootToggle);
        uiView.SetButton.onClick.AddListener(SetButton);
        uiView.mailButton.onClick.AddListener(MailButton);
        uiView.taskButton.onClick.AddListener(TaskButton);
        uiView.PlayerInfoButton.onClick.AddListener(PalyerInfoButton);
        ChatRootToggle(uiView.chatToggle.isOn);
    }

    private void ActiveButton()
    {
        MessageHelper.TopMessage("敬请期待");
    }

    private void OpenRoom()
    {
        Main.ClientManager.SendRequest(RequestCode.Room, ActionCode.ListRoom, "r");
        uiView.Room.SetActive(true);
    }

    private void PalyerInfoButton()
    {

    }

    private void TaskButton()
    {
        Main.UIManager.OpenPanel<UITaskLogic>(UIType.UITask);
    }

    private void MailButton()
    {
        Debug.Log("UIMail");
        Main.UIManager.OpenPanel<UIMailLogic>(UIType.UIMail);
    }

    private void SetButton()
    {
        Main.UIManager.OpenPanel<UISettingLogic>(UIType.UISetting);
    }

    private void RecordButton()
    {
        Main.UIManager.OpenPanel<UIRankingLogic>(UIType.UIRanking);
    }

    private void FrientButton()
    {
        Main.UIManager.OpenPanel<UIFriendLogic>(UIType.UIFriends);
    }

    private void ChatRootToggle(bool ison)
    {
        if (ison)
        {
            uiView.chatRoot.SetActive(true);
        }
        else
        {
            uiView.chatRoot.SetActive(false);
        }
    }

    private void BagButton()
    {
        Main.UIManager.OpenPanel<UIBagLogic>(UIType.UIBag);
    }

    private void ReFreshButton()
    {
        Main.ClientManager.SendRequest(RequestCode.Room, ActionCode.ListRoom, "r");
    }

    private void CreateRoomButton()
    {
        Main.ClientManager.SendRequest(RequestCode.Room, ActionCode.CreateRoom, "r");
    }

    public void SetName(string value)
    {
        uiView.nameText.text = value;
    }
    public void SetWin(string value)
    {
        uiView.winText.text = value;
    }
    public void SetTotol(string value)
    {
        uiView.totolText.text = value;
    }
    public RoleType RoleType;
    public override void DeInit()
    {
        Main.RequestManager.RemoveRequest(ActionCode.CreateRoom);
        Main.RequestManager.RemoveRequest(ActionCode.ListRoom);
        Main.RequestManager.RemoveRequest(ActionCode.JoinRoom);
    }
    public  void Start()
    {
        gameObject.SetActive(true);
        //Main.RequestManager.AddRequest(ActionCode.CreateRoom, new CreateRoomRequest(RequestCode.Room, ActionCode.CreateRoom, (data) =>
        //   {

        //   }));
        Main.RequestManager.AddRequest(ActionCode.ListRoom, new ListRoomRequest(RequestCode.Room, ActionCode.ListRoom, (data) =>
           {
               List<UserData> udList = new List<UserData>();
               if (data != "0")
               {
                   string[] udArray = data.Split('|');
                   foreach (string ud in udArray)
                   {
                       string[] strs = ud.Split(',');
                       udList.Add(new UserData(int.Parse(strs[0]), strs[1], int.Parse(strs[2]), int.Parse(strs[3])));
                   }
               }
               ShowRoomList(udList);
           }));
        Main.RequestManager.AddRequest(ActionCode.CreateRoom, new ListRoomRequest(RequestCode.Room, ActionCode.CreateRoom, (data) =>
        {
            string[] strs = data.Split(',');
            ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
            RoleType roleType = (RoleType)int.Parse(strs[1]);
            this.RoleType = roleType;
            if (returnCode == ReturnCode.Success)
            {
                //roomPanel.SetLocalPlayerResSync();
                //Main.UIManager.ClosePanel<UIGameMainLogic>(UIType.UIGameMain);
                //Main.UIManager.PopPanel();
                RoleData roleData = new RoleData() { RoleType = roleType,userdata=Main.GameManager.UserData };
                RoleType =Main.GameManager.RoleType;

                Main.UIManager.OpenPanel<UIRoomLogic>(UIType.UIRoom);
                Main.UIManager.GetPanel<UIRoomLogic>(UIType.UIRoom).SetContent(roleData);
            }
        }));
        Main.RequestManager.AddRequest(ActionCode.JoinRoom, new JoinRoomRequest(RequestCode.Room, ActionCode .JoinRoom, (data) => {
            string[] strs = data.Split('-');
            string[] strs2 = strs[0].Split(',');
            ReturnCode returnCode = (ReturnCode)int.Parse(strs2[0]);
            UserData ud1 = null;
            UserData ud2 = null;
            if (returnCode == ReturnCode.Success)
            {
                string[] udStrArray = strs[1].Split('|');
                ud1 = new UserData(udStrArray[0]);
                ud2 = new UserData(udStrArray[1]);
                List<UserData> userDatas = new List<UserData>();
                userDatas.Clear();
                userDatas.Add(ud1);
                userDatas.Add(ud2);
                RoleType roleType = (RoleType)int.Parse(strs2[1]);
                //facade.SetCurrentRoleType(roleType);
                switch (returnCode)
                {
                    case ReturnCode.NotFound:
                        Debug.Log("房间被销毁无法加入");
                        MessageHelper.TopMessage("房间被销毁无法加入");
                        break;
                    case ReturnCode.Fail:
                        Debug.Log("房间已满，无法加入");
                        MessageHelper.TopMessage("房间已满，无法加入");
                        break;
                    case ReturnCode.Success:
                        //Main.UIManager.ClosePanel<UIGameMainLogic>(UIType.UIGameMain);
                        Main.UIManager.OpenPanel<UIRoomLogic>(UIType.UIRoom);
                        Dictionary<RoleType, RoleData> royodic = new Dictionary<RoleType, RoleData>();
                        royodic.Clear();
                        for (int i = 0; i < userDatas.Count; i++)
                        {
                            if (userDatas[i].Username == Main.GameManager.UserData.Username)
                            {
                                RoleData roleData = new RoleData() { RoleType = roleType, userdata= userDatas[i] };
                               if(!royodic.ContainsKey(roleType))
                                    royodic.Add(roleType, roleData);
                            }
                            else 
                            {
                                if (roleType == RoleType.Blue)
                                {
                                    RoleData roleData1 = new RoleData() { RoleType = RoleType.Red, userdata = userDatas[i] };
                                    if(!royodic.ContainsKey(RoleType.Red))
                                        royodic.Add(RoleType.Red, roleData1);
                                }
                                else 
                                {
                                    RoleData roleData2 = new RoleData() { RoleType = RoleType.Blue, userdata = userDatas[i] };
                                    if (!royodic.ContainsKey(RoleType.Blue))
                                        royodic.Add(RoleType.Blue, roleData2);
                                }
                            }
                        }
                        //for (int i = 0; i < royodic.Keys.Count; i++)
                        //{
                        //    //Main.UIManager.GetPanel<UIRoomLogic>(UIType.UIRoom).SetContent(royodic.ElementAt(i).Value);
                        //    Main.UIManager.GetPanel<UIRoomLogic>(UIType.UIRoom).SetContent(royodic.Values.ElementAt(i));
                        //}
                        foreach (var item in royodic)
                        {
                            Main.UIManager.GetPanel<UIRoomLogic>(UIType.UIRoom).SetContent(item.Value);
                        }
                        break;
                }
            }
            //roomListPanel.OnJoinResponse(returnCode, ud1, ud2);

        }));
        //Main.ClientManager.SendRequest(RequestCode.Room, ActionCode.ListRoom, "r");
    }
    public void ShowRoomList(List<UserData> udList)
    {
        RoomItem[] riArray = uiView.Content.GetComponentsInChildren<RoomItem>();
        foreach (RoomItem ri in riArray)
        {
            ri.DestroySelf();
        }
        int count = udList.Count;
        GameObject profabs = Main.ResourcesManager.Load<GameObject>("UIItem/RoomItem");
        for (int i = 0; i < count; i++)
        {
            GameObject roomItem = GameObject.Instantiate(profabs);
            roomItem.transform.SetParent(uiView.Content.transform);
            roomItem.transform.localPosition = Vector3.zero;
            roomItem.transform.localScale = Vector3.one;
            roomItem.transform.localRotation = Quaternion.identity;
            roomItem.SetActive(true);
            UserData ud = udList[i];
            roomItem.GetComponent<RoomItem>().SetRoomInfo(ud.Id, ud.Username, ud.TotalCount, ud.WinCount);
        }                                                               
        int roomCount = GetComponentsInChildren<RoomItem>().Length;
        Vector2 size = uiView.Content.GetComponent<RectTransform>().sizeDelta;
        uiView.Content.GetComponent<RectTransform>().sizeDelta = new Vector2(size.x,
            roomCount * (profabs.GetComponent<RectTransform>().sizeDelta.y + uiView.layout.spacing));

    }
    private void BackButtonClick()
    {
        //Main.UIManager.ClosePanel<UIGameMainLogic>(UIType.UIGameMain);
        //Main.UIManager.OpenPanel<UILoginLogic>(UIType.UILogin);
        uiView.Room.SetActive(false);
    }
}
