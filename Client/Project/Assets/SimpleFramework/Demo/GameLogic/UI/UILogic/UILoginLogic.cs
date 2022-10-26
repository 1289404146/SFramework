using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoginLogic : UIBaseLogic
{
    public UILoginView uiView;
    Mirror.NetworkManager manager;

    public UILoginLogic()
    {
        uiLayer = UILayer.Default;
        uiType = UIType.UILogin;
    }
    private void Awake()
    {
        manager = GameObject.Find("NetworkManager").GetComponent<Mirror.NetworkManager>();

        uiView = new UILoginView();
        uiView.Init(transform);
        uiView.button1.onClick.AddListener(Button1Click);
        uiView.button2.onClick.AddListener(Button2Click);
        uiView.button3.onClick.AddListener(Button3Click);

    }
    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
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
    private void Button3Click()
    {
        manager.StartServer();
    }

    private void Button2Click()
    {
        Main.UIManager.PopPanel();
        manager.StartHost();
        Main.UIManager.PushPanel(UIType.UIGameMain);
    }

    private void Button1Click()
    {
        manager.StartClient();
    }
    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}
