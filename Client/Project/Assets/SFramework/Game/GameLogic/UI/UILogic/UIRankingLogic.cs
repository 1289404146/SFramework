using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRankingLogic : UIBaseLogic
{
    UIRankingView uiView;
    public UIRankingLogic()
    {
        uiType = UIType.UIRanking;
        uiLayer = UILayer.Default;
    }

    private void Awake()
    {
        uiView = new UIRankingView();
        uiView.Init(transform);
        uiView.backButton.onClick.AddListener(BackButton);
    }

    private void BackButton()
    {
        Main.UIManager.ClosePanel<UIRankingLogic>(UIType.UIRanking);
    }
}