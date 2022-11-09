using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomView : UIBaseView
{
    public Button start;
    public Button back;
    public Text redname;
    public Text redacount;
    public Text redpassword;
    public Text bluename;
    public Text blueacount;
    public Text bluepassword;
    public GameObject redGo;
    public GameObject blueGo;


    public override void Init(Transform transform)
    {
        start = transform.Find("StartButton").GetComponent<Button>();
        back = transform.Find("BackButton").GetComponent<Button>();
        redname = transform.Find("RedImage/RedNameText").GetComponent<Text>();
        redacount = transform.Find("RedImage/RedWinText").GetComponent<Text>();

        blueGo = transform.Find("BlueImage").gameObject;
        redGo = transform.Find("RedImage").gameObject;
        
        redpassword = transform.Find("RedImage/RedTotalText").GetComponent<Text>();
        bluename = transform.Find("BlueImage/BlueNameText").GetComponent<Text>();
        blueacount = transform.Find("BlueImage/BlueWinText").GetComponent<Text>();
        bluepassword = transform.Find("BlueImage/BlueTotalText").GetComponent<Text>();
    }
}
