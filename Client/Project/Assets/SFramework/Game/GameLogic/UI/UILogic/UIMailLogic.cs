
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class UIMailLogic : UIBaseLogic
{
    UIMailView uiView;
    public UIMailLogic()
    {
        uiType = UIType.UIMail;
        uiLayer = UILayer.Default;
    }

    private void Awake()
    {
        uiView = new UIMailView();
        uiView.Init(transform);
        uiView.BackButton.onClick.AddListener(BackButton);
    }

    private void BackButton()
    {
        Main.UIManager.ClosePanel<UIMailLogic>(UIType.UIMail);
    }
}
