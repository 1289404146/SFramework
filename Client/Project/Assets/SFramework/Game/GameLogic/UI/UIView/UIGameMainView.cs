using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


public class UIGameMainView : UIBaseView
{
    public Button createRoomButton;
    public Button backButton;
    public Button refreshButton;

    public Button bagButton;
    public Button recordButton;
    public Button friendButton;

    public Button mailButton;
    public Button taskButton;
    public Button SetButton;


    public Button PlayerInfoButton;

    public Text nameText;
    public Text winText;
    public Text totolText;

    public ScrollRect scrollRect;
    public GameObject Content;
    public VerticalLayoutGroup layout;
    public Toggle chatToggle;
    public GameObject chatRoot;



    public override void Init(Transform transform)
    {
        chatToggle = transform.Find("ChatToggle").GetComponent<Toggle>();
        chatRoot = transform.Find("ChatRoot").gameObject;
        PlayerInfoButton = transform.Find("PlayerInfo").GetComponent<Button>();
        nameText = transform.Find("PlayerInfo/Text").GetComponent<Text>();
        winText = transform.Find("PlayerInfo/Text1").GetComponent<Text>();
        totolText = transform.Find("PlayerInfo/Text2").GetComponent<Text>();

        scrollRect = transform.Find("Room/ScrollView").GetComponent<ScrollRect>();
        Content = transform.Find("Room/ScrollView/Viewport/Content").gameObject;
        layout = transform.Find("Room/ScrollView/Viewport/Content").GetComponent<VerticalLayoutGroup>();
        backButton = transform.Find("BackButton").GetComponent<Button>();
        createRoomButton = transform.Find("Room/CreateRoomButton").GetComponent<Button>();
        refreshButton = transform.Find("Room/RefreshButton").GetComponent<Button>();
        bagButton = transform.Find("Down/BagButton").GetComponent<Button>();
        recordButton = transform.Find("Down/RecordButton").GetComponent<Button>();
        friendButton = transform.Find("Down/FriendButton").GetComponent<Button>();
        mailButton = transform.Find("Down/MailButton").GetComponent<Button>();
        taskButton = transform.Find("Down/TaskButton").GetComponent<Button>();
        SetButton = transform.Find("Down/SetButton").GetComponent<Button>();
    }
}
