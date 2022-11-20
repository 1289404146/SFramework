
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIRoomLogic : UIBaseLogic
{
    public UIRoomView view;
    private bool isStartPlaying;
    private Dictionary<RoleType, RoleData> roleDataDict = new Dictionary<RoleType, RoleData>();
    private List<UserData> list = new List<UserData>();
    public UIRoomLogic()
    {
        uiLayer = UILayer.Default;
        uiType = UIType.UIRoom;
    }
    private void Awake()
    {
        view = new UIRoomView();
        view.Init(transform);
        view.start.onClick.AddListener(StartButton);
        view.back.onClick.AddListener(BackButton);

    }

    private void BackButton()
    {
        Main.ClientManager.SendRequest(RequestCode.Room, ActionCode.QuitRoom, "r");
    }

    private void StartButton()
    {
        Main.ClientManager.SendRequest(RequestCode.Game, ActionCode.StartGame, "r");
    }
    public override void DeInit()
    {
        base.DeInit();
        Main.RequestManager.RemoveRequest(ActionCode.StartGame);
        Main.RequestManager.RemoveRequest(ActionCode.StartPlay);
        Main.RequestManager.RemoveRequest(ActionCode.QuitRoom);
        Main.RequestManager.RemoveRequest(ActionCode.UpdateRoom);
    }
    public void Start()
    {
        gameObject.SetActive(true);
        //view.blueGo.SetActive(false);
        //view.redGo.SetActive(false);
        Main.RequestManager.AddRequest(ActionCode.StartGame, new StartPlayRequest(RequestCode.Game, ActionCode.StartGame, (data) =>
          {
              ReturnCode returnCode = (ReturnCode)int.Parse(data);
              if (returnCode == ReturnCode.Fail)
              {
                  MessageHelper.TopMessage("您不是房主，无法开始游戏！！");

                  Debug.Log("您不是房主，无法开始游戏！！");
              }
              else
              {
                  Main.Instance.AddComponentToMain<Empty>().DeInitilize();
                  Main.ScenesManager.LoadScene(SceneType.Game1);
                  //facade.EnterPlayingSync();
              }

          }));
        Main.RequestManager.AddRequest(ActionCode.StartPlay, new StartPlayRequest(RequestCode.Game, ActionCode.StartPlay, (data) =>
        {
            isStartPlaying = true;
            Debug.Log("StartPlay");
            MessageHelper.TopMessage("StartPlay");

            //facade.StartPlaying();
        }));
        Main.RequestManager.AddRequest(ActionCode.QuitRoom, new QuitRoomRequest(RequestCode.Room, ActionCode.QuitRoom, (data =>
           {
               ReturnCode returnCode = (ReturnCode)int.Parse(data);
               if (returnCode == ReturnCode.Success)
               {
                   Main.UIManager.ClosePanel<UIRoomLogic>(UIType.UIRoom);
                   Main.UIManager.OpenPanel<UIGameMainLogic>(UIType.UIGameMain);
               }
           })));
        Main.RequestManager.AddRequest(ActionCode.UpdateRoom, new UpdateRoomRequest(RequestCode.Room, ActionCode.UpdateRoom, (data) =>
           {
               UserData ud1 = null;
               UserData ud2 = null;
               string[] udStrArray = data.Split('|');
               list.Clear();
               ud1 = new UserData(udStrArray[0]);
               list.Add(ud1);
               if (udStrArray.Length > 1)
               {
                   ud2 = new UserData(udStrArray[1]);
                   list.Add(ud2);
               }
               for (int j = 0; j < list.Count; j++)
               {
                   if (list[j].Username == Main.GameManager.UserData.Username)
                   {
                       list.Remove(list[j]);
                   }
               }
               List<RoleData> dd = null;
               dd = roleDataDict.Values.ToList();
               for (int i = 0; i < dd.Count; i++)
               {
                   if (dd[i].RoleType == RoleType.Blue)
                   {
                       if (!roleDataDict.ContainsKey(RoleType.Red))
                           roleDataDict.Add(RoleType.Red, new RoleData() { RoleType = RoleType.Red, userdata = list[0] });
                   }
                   else
                   {
                       if (!roleDataDict.ContainsKey(RoleType.Blue))
                           roleDataDict.Add(RoleType.Blue, new RoleData() { RoleType = RoleType.Blue, userdata = list[0] });
                   }
                   SetContent(dd[i]);
               }
           }));
    }
    public void SetContent(RoleData roleData)
    {
        if (!roleDataDict.ContainsKey(roleData.RoleType))
        {
            roleDataDict.Add(roleData.RoleType, roleData);
        }
        foreach (var item in roleDataDict)
        {
            if (item.Value.RoleType == RoleType.Blue)
            {
                view.blueGo.SetActive(true);
                view.bluename.text = item.Value.userdata.Username;
                view.blueacount.text = item.Value.userdata.WinCount.ToString();
                view.bluepassword.text = item.Value.userdata.TotalCount.ToString();
                if (roleDataDict.Count < 2)
                {
                    SetRed();
                }
            }
            else
            {
                view.redGo.SetActive(true);
                view.redname.text = item.Value.userdata.Username;
                view.redacount.text = item.Value.userdata.WinCount.ToString();
                view.redpassword.text = item.Value.userdata.TotalCount.ToString();
                if (roleDataDict.Count < 2)
                {
                    SetBlue();
                }
            }
        }
    }
    public void SetRed()
    {
        view.redname.text = "等待加入";
        view.redacount.text = "等待加入";
        view.redpassword.text = "等待加入";
    }
    public void SetBlue()
    {
        view.bluename.text = "等待加入";
        view.blueacount.text = "等待加入";
        view.bluepassword.text = "等待加入";
    }
}
