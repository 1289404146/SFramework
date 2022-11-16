using Google.Protobuf;
using Person;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoginLogic : UIBaseLogic
{
    public UILoginView uiView;

    public UILoginLogic()
    {
        uiLayer = UILayer.Default;
        uiType = UIType.UILogin;
    }
    private void Awake()
    {
        //manager = GameObject.Find("NetworkManager").GetComponent<Mirror.NetworkManager>();

        uiView = new UILoginView();
        uiView.Init(transform);
        uiView.login.onClick.AddListener(LoginClick);
        uiView.quit.onClick.AddListener(QuitClick);
        uiView.regist.onClick.AddListener(RegistClick);
        uiView.acount.text = "666";
        uiView.password.text = "666";
    }
    public void Start()
    {
        gameObject.SetActive(true);
        Main.RequestManager.AddRequest(ActionCode.Login, new LoginRequest(RequestCode.User, ActionCode.Login, (data) => {
            string[] strs = data.Split(',');
            ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
            if (returnCode == ReturnCode.Success)
            {
                string username = strs[1];
                int totalCount = int.Parse(strs[2]);
                int winCount = int.Parse(strs[3]);

                //Main.ScenesManager.LoadScene(SceneType.Empty);
                UserData userData = new UserData(username, totalCount, winCount);
                Main.GameManager.UserData = userData;
                Debug.Log(data);

                Main.UIManager.ClosePanel<UILoginLogic>(UIType.UILogin);
                Main.ScenesManager.LoadScene(SceneType.Empty);

                //UserData ud = new UserData(username, totalCount, winCount);
                //facade.SetUserData(ud);
            }
            else
            {
                Debug.Log(data);
                Debug.Log("未找到");
            }
        }));
    }
    public override void DeInit()
    {
        base.DeInit();
        Main.RequestManager.RemoveRequest(ActionCode.Login);
    }
    private void RegistClick()
    {
        Main.UIManager.ClosePanel<UIRegistLogic>(UIType.UIRegist);
        Main.UIManager.OpenPanel<UILoginLogic>(UIType.UIRegist);
    }

    private void QuitClick()
    {
    }

    private void LoginClick()
    {
        string msg = "";
        if (string.IsNullOrEmpty(uiView.acount.text))
        {
            msg += "用户名不能为空 ";
        }
        if (string.IsNullOrEmpty(uiView.password.text))
        {
            msg += "密码不能为空 ";
        }
        if (msg != "")
        {
            Debug.Log(msg);
            return;
        }

        string data = uiView.acount.text + "," + uiView.password.text;
        //创建OnePerson对象并初始化
        OnePerson onePerson = new OnePerson();
        onePerson.Name = "张三";
        onePerson.IdNumber = 000001;
        onePerson.Gender = genders.Man;
        onePerson.Profession = "法外狂徒";
        //将onePerson对象转换为字节数组
        string dataByte = onePerson.ToString();

        Debug.Log(dataByte);
        Main.ClientManager.SendRequest(RequestCode.User, ActionCode.Login, data);
    }
    [Serializable]
    public class Person 
    {
        public int age ;
    }
}
