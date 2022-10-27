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
    public override void OnEnter()
    {
        base.OnEnter();
    }
    public override void OnPause()
    {
        base.OnPause();
    }
    public override void OnResume()
    {
        base.OnResume();
    }
    public override void OnExit()
    {
        base.OnExit();
    }
}
