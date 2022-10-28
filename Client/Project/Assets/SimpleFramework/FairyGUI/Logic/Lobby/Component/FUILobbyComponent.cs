using DCET.Hotfix;
using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class FUILobbyComponent:BaseFUI
{
    FUILobby fUILobby;
   public FUILobbyComponent()
    {
        fUILobby = FUILobby.CreateInstance();
        fUILobby.SetSize(GRoot.inst.width, GRoot.inst.height);
        GRoot.inst.AddChild(fUILobby);
        Debug.Log(fUILobby.bg.name);
    }
    public override void OnEnter()
    {
        base.OnEnter();
    }
}
