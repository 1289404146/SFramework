using DCET.Hotfix;
using FairyGUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class FUILobbyFactory
{
    public static FUILobby CtreatFUI()
    {
        HotfixBinder.BindAll();
        FUILobby view = FUILobby.CreateInstance();
        view.SetSize(GRoot.inst.width, GRoot.inst.height);
        GRoot.inst.AddChild(view);
        Debug.Log(view.bg.name);
        return view;
    }
}
