using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UILoginView : UIBaseView
{
    public Button button1;
    public Button button2;
    public Button button3;

    public override void Init(Transform transform)
    {
        button1 = transform.Find("Button1").GetComponent<Button>();
        button2 = transform.Find("Button2").GetComponent<Button>();
        button3 = transform.Find("Button3").GetComponent<Button>();

    }
}
