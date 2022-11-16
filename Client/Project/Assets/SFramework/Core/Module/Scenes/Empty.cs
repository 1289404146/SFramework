using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Empty : BaseMono, IScene
{
    public void DeInitilize()
    {
        Debug.Log("Empty_____DeInitilize");
        Main.UIManager.ClosePanel<UIGameMainLogic>(UIType.UIGameMain);
    }

    public void Initilize()
    {
        Debug.Log("Empty_____Initilize");
        //Main.UIManager.PushPanel(UIType.UIMain);
        Main.UIManager.OpenPanel<UIGameMainLogic>(UIType.UIGameMain);
        Main.UIManager.GetPanel<UIGameMainLogic>(UIType.UIGameMain).SetName(Main.GameManager.UserData.Username);
        Main.UIManager.GetPanel<UIGameMainLogic>(UIType.UIGameMain).SetWin(Main.GameManager.UserData.WinCount.ToString());
        Main.UIManager.GetPanel<UIGameMainLogic>(UIType.UIGameMain).SetTotol(Main.GameManager.UserData.TotalCount.ToString());
        //Main.FUIManager.OpenPanel<FUILoginComponent>();

    }
}
