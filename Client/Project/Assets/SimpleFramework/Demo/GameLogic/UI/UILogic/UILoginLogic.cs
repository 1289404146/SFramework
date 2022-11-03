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

    }
    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        LoginRequest loginRequest = new LoginRequest(RequestCode.User, ActionCode.Login, (data) => {
            string[] strs = data.Split(',');
            ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
            this.returnCode = returnCode;
            if (returnCode == ReturnCode.Success)
            {
                string username = strs[1];
                int totalCount = int.Parse(strs[2]);
                int winCount = int.Parse(strs[3]);
                Debug.Log("未找到");
                //UserData ud = new UserData(username, totalCount, winCount);
                //facade.SetUserData(ud);
            }
            else {

                Debug.Log("未找到");
            }

        });
        Main.RequestManager.AddRequest(ActionCode.Login, loginRequest);
    }
    ReturnCode returnCode;
    private void Update()
    {

        if (returnCode!=ReturnCode.Success)
        {
            Main.UIManager.PopPanel();
            Main.UIManager.PushPanel(UIType.UIRegist);
        }
    }
    public override void OnPause()
    {
        base.OnPause();
        gameObject.SetActive(false);
    }
    public override void OnResume()
    {
        base.OnResume();
        gameObject.SetActive(true);
    }
    public void Close(ReturnCode dd)
    {
        if (dd!=ReturnCode.Success)
        {
            Main.UIManager.PopPanel();
            Main.UIManager.PushPanel(UIType.UIRegist);
        }
    }
    private void RegistClick()
    {
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
        Debug.Log(data);
        Main.ClientManager.SendRequest(RequestCode.User, ActionCode.Login, data);
    }
    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}
