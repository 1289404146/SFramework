using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UILoginView : UIBaseView
{
    public Button login;
    public Button quit;
    public Button regist;
    public InputField name;
    public InputField acount;
    public InputField password;


    public override void Init(Transform transform)
    {
        login = transform.Find("Button1").GetComponent<Button>();
        quit = transform.Find("Button2").GetComponent<Button>();
        regist = transform.Find("Button3").GetComponent<Button>();
        name = transform.Find("InputFieldName").GetComponent<InputField>();
        acount = transform.Find("InputFieldID").GetComponent<InputField>();
        password = transform.Find("InputFieldPass").GetComponent<InputField>();
    }
}
