using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UIRegistLogic : UIBaseLogic
{
    public UIRegistView view;
    public UIRegistLogic()
    {
        uiLayer = UILayer.Default;
        uiType = UIType.UIRegist;
    }
    private void Awake()
    {
        view = new UIRegistView();
        view.Init(transform);
        view.back.onClick.AddListener(BackToLogin);
        view.confirm.onClick.AddListener(ConfirmButton);

    }

    private void ConfirmButton()
    {
        string msg = "";
        if (string.IsNullOrEmpty(view.acount.text))
        {
            msg += "用户名不能为空 ";
        }
        if (string.IsNullOrEmpty(view.password.text))
        {
            msg += "密码不能为空 ";
        }
        if (msg != "")
        {
            Debug.Log(msg);
            return;
        }

        string data = view.acount.text + "," + view.password.text;
        Main.ClientManager.SendRequest(RequestCode.User,ActionCode.Register, data);
    }

    private void BackToLogin()
    {
        Debug.Log("CLick");
        Main.UIManager.PopPanel();
        Main.UIManager.PushPanel<UILoginLogic>(UIType.UILogin);
    }

    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
        Main.RequestManager.AddRequest(ActionCode.Register, new RegisterRequest(RequestCode.User, ActionCode.Register, (data) =>
          {

              ReturnCode returnCode = (ReturnCode)int.Parse(data);
              if (returnCode == ReturnCode.Success)
              {
                  Debug.Log("注册成功");
              }
              else
              {
                  Debug.Log("注册失败");
              }
          }));
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
    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}
