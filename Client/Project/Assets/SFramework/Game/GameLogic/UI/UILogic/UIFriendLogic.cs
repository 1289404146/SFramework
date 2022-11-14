using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFriendLogic : UIBaseLogic
{
    UIFriendView uiView;
    public UIFriendLogic()
    {
        uiType = UIType.UIFriends;
        uiLayer = UILayer.Default;
    }

    private void Awake()
    {
        uiView = new UIFriendView();
        uiView.Init(transform);
        AddEvent();
    }
    private void AddEvent()
    {
        uiView.BackButton.onClick.AddListener(CloseFriend);
    }

    private void CloseFriend()
    {
        Main.UIManager.ClosePanel<UIFriendLogic>(UIType.UIFriends);
    }
}