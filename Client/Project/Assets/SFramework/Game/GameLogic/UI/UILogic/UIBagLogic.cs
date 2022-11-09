using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class UIBagLogic : UIBaseLogic
{
    public UIBagView uiView;

    public UIBagLogic()
    {
        uiType = UIType.UIBag;
        uiLayer = UILayer.Default;
    }

    private void Awake()
    {
        uiView = new UIBagView();
        uiView.Init(transform);
    }
    private void Start()
    {
        uiView.backButton.onClick.AddListener(BackButton);
    }

    private void BackButton()
    {
        Main.UIManager.ClosePanel<UIBagLogic>(UIType.UIBag);
    }
}
