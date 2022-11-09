using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIRegistView : UIBaseView
{
    public Button confirm;
    public Button back;
    public InputField name;
    public InputField acount;
    public InputField password;


    public override void Init(Transform transform)
    {
        confirm = transform.Find("Button1").GetComponent<Button>();
        back = transform.Find("Button3").GetComponent<Button>();
        name = transform.Find("InputFieldName").GetComponent<InputField>();
        acount = transform.Find("InputFieldID").GetComponent<InputField>();
        password = transform.Find("InputFieldPass").GetComponent<InputField>();
    }
}
