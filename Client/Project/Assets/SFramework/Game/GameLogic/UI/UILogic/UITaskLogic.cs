using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class UITaskLogic:UIBaseLogic
    {
        UITaskView uiView;
        public UITaskLogic()
        {
            uiType = UIType.UITask;
            uiLayer = UILayer.Default;
        }

        private void Awake()
        {
            uiView = new UITaskView();
            uiView.Init(transform);
            uiView.BackButton.onClick.AddListener(BackButton);
        }

        private void BackButton()
        {
            Main.UIManager.ClosePanel<UITaskLogic>(UIType.UITask);
        }
    }
