using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIMessageView : UIBaseView
{
    public Text text;


    public override void Init(Transform transform)
    {
        text = transform.Find("Message/Text").GetComponent<Text>();
    }
}