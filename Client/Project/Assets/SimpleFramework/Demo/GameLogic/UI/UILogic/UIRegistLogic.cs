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
    }

    private void BackToLogin()
    {
        Debug.Log("CLick");
        Main.UIManager.PopPanel();
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
}
