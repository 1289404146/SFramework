using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UISettingLogic : UIBaseLogic
{
    UISettingView uiView;
    public UISettingLogic()
    {
        uiType = UIType.UISetting;
        uiLayer = UILayer.Default;
    }

    private void Awake()
    {
        uiView = new UISettingView();
        uiView.Init(transform);
        uiView.backButton.onClick.AddListener(BackButton);
    }

    private void BackButton()
    {
        Main.UIManager.ClosePanel<UISettingLogic>(UIType.UISetting);
    }
}