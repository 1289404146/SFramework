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
    }

    public void Initilize()
    {
        Debug.Log("Empty_____Initilize");
        //Main.UIManager.PushPanel(UIType.UIMain);
        Main.UIManager.PushPanel(UIType.UILogin);
        //Main.FUIManager.OpenPanel<FUILoginComponent>();

    }
}
