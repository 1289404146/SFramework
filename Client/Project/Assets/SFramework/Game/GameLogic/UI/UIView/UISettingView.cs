using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UISettingView : UIBaseView
{
    public Button backButton;
    public override void Init(Transform transform)
    {
        backButton = transform.Find("BackButton").GetComponent<Button>();
    }
}
