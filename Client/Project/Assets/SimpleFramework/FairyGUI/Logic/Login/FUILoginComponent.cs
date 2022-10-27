using DCET.Hotfix;
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUILoginComponent:BaseFUI
{
    public override void AddListener()
    {
        base.AddListener();
        _view.GetChild("loginButton").asButton.onClick.Add(Click);
    }

    private void Click(EventContext context)
    {
        //Main.FUIManager.CloseFUI(FUIType.UILogin);
        Main.FUIManager.OpenFUI(FUIType.UILogin);
    }

    public override void OnBeforeCreate()
    {
        base.OnBeforeCreate();
    }
    public override void OnCreate()
    {
        base.OnCreate(); 
    }
    public override void OnHide()
    {
        base.OnHide();
    }
    public override void OnDestory()
    {
        base.OnDestory();
    }
    public override void OnRefresh()
    {
        base.OnRefresh();
    }

}
