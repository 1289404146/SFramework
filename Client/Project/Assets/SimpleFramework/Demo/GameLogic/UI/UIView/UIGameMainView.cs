using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class UIGameMainView : UIBaseView
{
    public Button button;
    public override void Init(Transform transform)
    {
        button = transform.Find("Button1").GetComponent<Button>();
    }
}
