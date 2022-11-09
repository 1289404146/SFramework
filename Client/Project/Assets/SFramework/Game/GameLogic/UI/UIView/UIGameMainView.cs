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
        nameText = transform.Find("Text").GetComponent<Text>();
        winText = transform.Find("Text1").GetComponent<Text>();
        totolText = transform.Find("Text2").GetComponent<Text>();
        scrollRect = transform.Find("ScrollView").GetComponent<ScrollRect>();
        Content = transform.Find("ScrollView/Viewport/Content").gameObject;
        layout = transform.Find("ScrollView/Viewport/Content").GetComponent<VerticalLayoutGroup>();
        backButton = transform.Find("BackButton").GetComponent<Button>();
        createRoomButton = transform.Find("CreateRoomButton").GetComponent<Button>();
        refreshButton = transform.Find("RefreshButton").GetComponent<Button>();
        bagButton = transform.Find("Down/BagButton").GetComponent<Button>();
        recordButton = transform.Find("Down/RecordButton").GetComponent<Button>();
        friendButton = transform.Find("Down/FriendButton").GetComponent<Button>();
    }
}
