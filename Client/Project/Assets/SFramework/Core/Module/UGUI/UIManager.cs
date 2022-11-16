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
        dicPath[UIType.UILoading] = "UIPanel/UILoading";
        dicPath[UIType.UIRoom] = "UIPanel/UIRoom";
        dicPath[UIType.UILogin] = "UIPanel/UILogin";
        dicPath[UIType.UIRegist] = "UIPanel/UIRegist";
        dicPath[UIType.UIMain] = "UIPanel/UIMain";
        dicPath[UIType.UIActivity] = "UIPanel/UIActivity";
        dicPath[UIType.UIPlayerInformation] = "UIPanel/UIPlayerInformation";
        dicPath[UIType.UIShopping] = "UIPanel/UIShopping";
        dicPath[UIType.UICollection] = "UIPanel/UICollection";
        dicPath[UIType.UIRanking] = "UIPanel/UIRanking";
        dicPath[UIType.UIBag] = "UIPanel/UIBag";
        dicPath[UIType.UITask] = "UIPanel/UITask";
        dicPath[UIType.UIMail] = "UIPanel/UIMail";
        dicPath[UIType.UIFriends] = "UIPanel/UIFriends";
        dicPath[UIType.UISelectLevel] = "UIPanel/UISelectLevel";
        dicPath[UIType.UIGameStart] = "UIPanel/UIGameStart";
        dicPath[UIType.UIGameMain] = "UIPanel/UIGameMain";
        dicPath[UIType.UIGameEnd] = "UIPanel/UIGameEnd";
        dicPath[UIType.UISetting] = "UIPanel/UISetting";
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
        if (dicPanel == null)
            dicPanel = new Dictionary<string, UIBaseLogic>();
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

    /// <summary>
    /// 打开面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T OpenPanel<T>(string panelName) where T : UIBaseLogic
    {
        if (dicPanel.ContainsKey(panelName))
        {
            return dicPanel[panelName] as T;
        }
        string path = string.Empty;
        if (dicPath.ContainsKey(panelName))
            path = dicPath[panelName];
        else
            return null;

        GameObject go = Resources.Load<GameObject>(path);
        GameObject goPanel = GameObject.Instantiate(go, canvasTf, false);
        UIBaseLogic panel = goPanel.GetComponent<UIBaseLogic>();
        goPanel.transform.SetParent(Main.UIManager.dicLayer[panel.uiLayer]);
        panel.OnInit();
        dicPanel.Add(panelName, panel);
        return panel as T;
    }
    /// <summary>
    /// 获取面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetPanel<T>(string panelName) where T : UIBaseLogic
    {
        if (dicPanel.ContainsKey(panelName))
        {
            return dicPanel[panelName] as T;
        }
        return null;
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ClosePanel<T>(string panelName)
    {
        if (dicPanel.ContainsKey(panelName))
        {
            dicPanel[panelName].DeInit();
            //销毁场景中的游戏对象
            Destroy(dicPanel[panelName].gameObject);
            //销毁内存中的引用
            dicPanel.Remove(panelName);
        }
    }
    /// <summary>
    /// 关闭所有的面板
    /// </summary>
    public void CloseAll()
    {
        foreach (var item in dicPanel)
        {
            Destroy(dicPanel[item.Key].gameObject);
        }
        dicPanel.Clear();
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
