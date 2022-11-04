using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseMono,IManager
{
    //所有UI面板perfab的路径key：UIType——value：Resources下的路径
    public Dictionary<string, string> dicPath;
    //根据上面路径，加载的好的具体的UI面板类
    public Dictionary<string, UIBaseLogic> dicPanel;
    //栈存储所有打开的UI面板,打开UI，push栈，关闭UI，pop栈
    private Stack<UIBaseLogic> panelStack;
    //canvas.transform 方便设置父节点
    private Transform canvasTf;
    //存储UI层级节点，方便设置父节点
    public Dictionary<UILayer, Transform> dicLayer;
    //存储UI层级对应的名称，用来加载ui层级节点时命名
    public Dictionary<UILayer, string> dicLayerName;

    private UIManager()
    {
        Debug.Log("UIManager------UIManager");

        //初始化perfab路径和ui层级节点
        InitPath();
        InitUILayer();
    }
    private void InitPath()
    {
        dicPath = new Dictionary<string, string>();
        //自动生成代码，或使用json加载
        dicPath[UIType.UILoading.ToLower()] = "UIPanel/UILoading";
        dicPath[UIType.UILogin.ToLower()] = "UIPanel/UILogin";
        dicPath[UIType.UIRegist.ToLower()] = "UIPanel/UIRegist";
        dicPath[UIType.UIMain.ToLower()] = "UIPanel/UIMain";
        dicPath[UIType.UIActivity.ToLower()] = "UIPanel/UIActivity";
        dicPath[UIType.UIPlayerInformation.ToLower()] = "UIPanel/UIPlayerInformation";
        dicPath[UIType.UIShopping.ToLower()] = "UIPanel/UIShopping";
        dicPath[UIType.UICollection.ToLower()] = "UIPanel/UICollection";
        dicPath[UIType.UIRanking.ToLower()] = "UIPanel/UIRanking";
        dicPath[UIType.UIBag.ToLower()] = "UIPanel/UIBag";
        dicPath[UIType.UITask.ToLower()] = "UIPanel/UITask";
        dicPath[UIType.UIUnion.ToLower()] = "UIPanel/UIUnion";
        dicPath[UIType.UIFriends.ToLower()] = "UIPanel/UIFriends";
        dicPath[UIType.UISelectLevel.ToLower()] = "UIPanel/UISelectLevel";
        dicPath[UIType.UIGameStart.ToLower()] = "UIPanel/UIGameStart";
        dicPath[UIType.UIGameMain.ToLower()] = "UIPanel/UIGameMain";
        dicPath[UIType.UIGameEnd.ToLower()] = "UIPanel/UIGameEnd";
}

    private void InitUILayer()
    {
        dicLayerName = new Dictionary<UILayer, string>();
        dicLayerName.Add(UILayer.Back, "Front");
        dicLayerName.Add(UILayer.Default, "Default");
        dicLayerName.Add(UILayer.Pop, "Pop");
        dicLayerName.Add(UILayer.Top, "Top");
    }

    public void Awake()
    {
        canvasTf = GameObject.Find("Canvas").transform;
        Debug.Log("UIManager------Awake");
        //加载层级节点   
        LoadLayer();
    }
    private void Start()
    {
        Debug.Log("UIManager------Start");
    }

    private void LoadLayer()
    {
        dicLayer = new Dictionary<UILayer, Transform>();
        for (int i = 0; i < dicLayerName.Count; ++i)
        {
            GameObject layer = new GameObject(dicLayerName[(UILayer)i]);
            layer.transform.SetParent(canvasTf);
            dicLayer.Add((UILayer)i, layer.transform);
        }
    }

    //获取dicPanel中存储的基层UIBase的类，如果为空，先加载添加进去
    public T GetPanel<T>(string panelType)where T : UIBaseLogic
    {
        if (dicPanel == null)
            dicPanel = new Dictionary<string, UIBaseLogic>();

        panelType = panelType.ToLower();
        if (dicPanel.ContainsKey(panelType))
            return dicPanel[panelType] as T;
        else
        {
            string path = string.Empty;
            if (dicPath.ContainsKey(panelType))
                path = dicPath[panelType];
            else
                return null;

            GameObject go = Resources.Load<GameObject>(path);
            GameObject goPanel = GameObject.Instantiate(go, canvasTf, false);
            UIBaseLogic panel = goPanel.GetComponent<UIBaseLogic>();
            dicPanel.Add(panelType, panel);
            return panel as T;
        }
    }

    //打开UI界面
    public void PushPanel<T>(string panelType)where T: UIBaseLogic
    {
        if (panelStack == null)
        {
            panelStack = new Stack<UIBaseLogic>();
        }

        //停止上一个界面
        if (panelStack.Count > 0)
        {
            UIBaseLogic top = panelStack.Peek();
            top.OnPause();
        }

        UIBaseLogic panel = GetPanel<T>(panelType);
        panelStack.Push(panel);
        panel.OnEnter();
    }

    //关闭最上层界面
    public void PopPanel()
    {
        if (panelStack == null)
        {
            panelStack = new Stack<UIBaseLogic>();
        }
        if (panelStack.Count <= 0)
        {
            return;
        }

        //退出栈顶面板
        UIBaseLogic top = panelStack.Pop();
        top.OnExit();

        //恢复上一个面板
        if (panelStack.Count > 0)
        {
            UIBaseLogic panel = panelStack.Peek();
            panel.OnResume();
        }
    }

    //获取最上层面板
    public UIBaseLogic GetTopPanel()
    {
        if (panelStack.Count > 0)
            return panelStack.Peek();
        else
            return null;
    }

    public void Initilize()
    {
        Debug.Log("UIManager------Initilize");
    }

    public void DeInitilize()
    {
        Debug.Log("UIManager------DeInitilize");
    }
}
