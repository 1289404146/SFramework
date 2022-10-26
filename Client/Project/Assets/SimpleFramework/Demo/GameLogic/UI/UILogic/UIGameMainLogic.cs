using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UIGameMainLogic : UIBaseLogic
{

    public UIGameMainView uiView;
    Mirror.NetworkManager manager;

    public UIGameMainLogic()
    {
        uiLayer = UILayer.Default;
        uiType = UIType.UIGameMain;
    }

    private void Awake()
    {
        manager = GameObject.Find("NetworkManager").GetComponent<Mirror.NetworkManager>();
        uiView = new UIGameMainView();
        uiView.Init(transform);
        uiView.button.onClick.AddListener(Button1Click);
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
    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
    private void Button1Click()
    {
        manager.StopHost();
        Main.UIManager.PopPanel();
        Main.UIManager.PushPanel(UIType.UILogin);

    }
}
