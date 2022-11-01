using DCET.Hotfix;
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUILoginComponent : BaseFUI
{
    FUILogin fuilogin;

    public FUILoginComponent()
    {
        HotfixBinder.BindAll();
        fuilogin = FUILogin.CreateInstance();
        fuilogin.SetSize(GRoot.inst.width, GRoot.inst.height);
        GRoot.inst.AddChild(fuilogin);
        Debug.Log(fuilogin.bg.name);
    }
    public override void OnEnter()
    {
        base.OnEnter();
        fuilogin.loginButton.onClick.Add(() =>
        {
            Main.FUIManager.ClosePanel<FUILoginComponent>();
            Main.FUIManager.OpenPanel<FUILobbyComponent>();
        });
    }
    public override void OnExit()
    {
        base.OnExit();
        fuilogin.Dispose();
    }
}
