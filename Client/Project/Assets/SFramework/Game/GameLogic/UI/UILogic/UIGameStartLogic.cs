using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UIGameStartLogic : UIBaseLogic
{
    UIGameStartView uiView;
    public UIGameStartLogic()
    {
        uiType = UIType.UIGameStart;
        uiLayer = UILayer.Default;
    }

    private void Awake()
    {
        uiView = new UIGameStartView();
        uiView.Init(transform);
        AddEvent();
    }
    private void AddEvent()
    {
        uiView.BackButton.onClick.AddListener(CloseFriend);
    }

    private void CloseFriend()
    {
        Main.Instance.AddComponentToMain<Game>().DeInitilize();
        Main.ScenesManager.LoadScene(SceneType.Empty);
    }
}
