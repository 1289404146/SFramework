using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

class UIGameStartView : UIBaseView
{
    public Button BackButton;
    public GameObject Air;
    public override void Init(Transform transform)
    {
        BackButton = transform.Find("BackButton").GetComponent<Button>();
        Air = transform.Find("Ear").gameObject;
    }
}
