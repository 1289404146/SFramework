using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIMainView : UIBaseView
{
    public GameObject mail1RedPoint;
    public GameObject mail2RedPoint;
    public GameObject mail3RedPoint;
    public GameObject mail4RedPoint;
    public GameObject mail5RedPoint;
    public GameObject mail6RedPoint;

    public Text txtMail1;
    public Text txtMail2;
    public Text txtMail3;
    public Text txtMail4;
    public Text txtMail5;
    public Text txtMail6;

    public Button mail4Btn;
    public Button mail5Btn;
    public Button mail6Btn;
    public Button btnSet1;
    public Button btnSet2;
    public Button btnSet3;
    public override void Init(Transform transform)
    {
        mail1RedPoint = transform.Find("Image/Image/Image").gameObject;
        mail2RedPoint = transform.Find("Image/Image1/Image").gameObject;
        mail3RedPoint = transform.Find("Image/Image2/Image").gameObject;
        mail4RedPoint = transform.Find("Button/Button00/Image").gameObject;
        mail5RedPoint = transform.Find("Button/Button11/Image").gameObject;
        mail6RedPoint = transform.Find("Button/Button22/Image").gameObject;

        txtMail1 = transform.Find("Image/Image/Text").GetComponent<Text>();
        txtMail2 = transform.Find("Image/Image1/Text").GetComponent<Text>();
        txtMail3 = transform.Find("Image/Image2/Text").GetComponent<Text>();
        txtMail4 = transform.Find("Button0/Text").GetComponent<Text>();
        txtMail5 = transform.Find("Button1/Text").GetComponent<Text>();
        txtMail6 = transform.Find("Button2/Text").GetComponent<Text>();


        mail4Btn = transform.Find("Button/Button00").GetComponent<Button>();
        mail4Btn = transform.Find("Button/Button11").GetComponent<Button>();
        mail6Btn = transform.Find("Button/Button22").GetComponent<Button>();

        btnSet1 = transform.Find("Button0").GetComponent<Button>();
        btnSet2 = transform.Find("Button1").GetComponent<Button>();
        btnSet3 = transform.Find("Button2").GetComponent<Button>();

    }
}
