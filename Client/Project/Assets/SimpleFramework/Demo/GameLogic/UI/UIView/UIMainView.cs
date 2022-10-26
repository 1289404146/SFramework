using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIMainView : UIBaseView
{
    public Text sText;
    public Text sText1;
    public Button Button;
    public override void Init(Transform transform)
    {
        sText = transform.Find("Toggle/Label").GetComponent<Text>();
        sText1 = transform.Find("Text").GetComponent<Text>();
        Button = transform.Find("Button").GetComponent<Button>();
    }
}
