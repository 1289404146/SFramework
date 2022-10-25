using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBase,IManager
{
    //所有UI面板perfab的路径key：UIType——value：Resources下的路径
    public Dictionary<string, string> dicPath;
    //根据上面路径，加载的好的具体的UI面板类
    public Dictionary<string, UIBase> dicPanel;
    //栈存储所有打开的UI面板,打开UI，push栈，关闭UI，pop栈
    private Stack<UIBase> panelStack;
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
        dicPath["panmain"] = "UIPanel/PanMain";
        //dicPath["paninventory"] = "UIPanel/paninventory";
        //dicPath["panskill"] = "UIPanel/panskill";
        //dicPath["panquest"] = "UIPanel/panquest";
        //dicPath["panequipment"] = "UIPanel/panequipment";
        //dicPath["panshop"] = "UIPanel/panshop";
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
    private UIBase GetPanel(string panelType)
    {
        if (dicPanel == null)
            dicPanel = new Dictionary<string, UIBase>();

        panelType = panelType.ToLower();
        if (dicPanel.ContainsKey(panelType))
            return dicPanel[panelType];
        else
        {
            string path = string.Empty;
            if (dicPath.ContainsKey(panelType))
                path = dicPath[panelType];
            else
                return null;

            GameObject go = Resources.Load<GameObject>(path);
            GameObject goPanel = GameObject.Instantiate(go, canvasTf, false);
            UIBase panel = goPanel.GetComponent<UIBase>();
            dicPanel.Add(panelType, panel);
            return panel;
        }
    }

    //打开UI界面
    public void PushPanel(string panelType)
    {
        if (panelStack == null)
        {
            panelStack = new Stack<UIBase>();
        }

        //停止上一个界面
        if (panelStack.Count > 0)
        {
            UIBase top = panelStack.Peek();
            top.OnPause();
        }

        UIBase panel = GetPanel(panelType);
        panelStack.Push(panel);
        panel.OnEnter();
    }

    //关闭最上层界面
    public void PopPanel()
    {
        if (panelStack == null)
        {
            panelStack = new Stack<UIBase>();
        }
        if (panelStack.Count <= 0)
        {
            return;
        }

        //退出栈顶面板
        UIBase top = panelStack.Pop();
        top.OnExit();

        //恢复上一个面板
        if (panelStack.Count > 0)
        {
            UIBase panel = panelStack.Peek();
            panel.OnResume();
        }
    }

    //获取最上层面板
    public UIBase GetTopPanel()
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
