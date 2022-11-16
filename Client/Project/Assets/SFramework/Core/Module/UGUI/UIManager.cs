using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseMono,IManager
{
    //����UI���perfab��·��key��UIType����value��Resources�µ�·��
    public Dictionary<string, string> dicPath;
    //��������·�������صĺõľ����UI�����
    public Dictionary<string, UIBaseLogic> dicPanel;
    //ջ�洢���д򿪵�UI���,��UI��pushջ���ر�UI��popջ
    private Stack<UIBaseLogic> panelStack;
    //canvas.transform �������ø��ڵ�
    private Transform canvasTf;
    //�洢UI�㼶�ڵ㣬�������ø��ڵ�
    public Dictionary<UILayer, Transform> dicLayer;
    //�洢UI�㼶��Ӧ�����ƣ���������ui�㼶�ڵ�ʱ����
    public Dictionary<UILayer, string> dicLayerName;

    private UIManager()
    {
        Debug.Log("UIManager------UIManager");

        //��ʼ��perfab·����ui�㼶�ڵ�
        InitPath();
        InitUILayer();
    }
    private void InitPath()
    {
        dicPath = new Dictionary<string, string>();
        //�Զ����ɴ��룬��ʹ��json����
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
        //���ز㼶�ڵ�   
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
    /// �����
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
    /// ��ȡ���
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
    /// �ر����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ClosePanel<T>(string panelName)
    {
        if (dicPanel.ContainsKey(panelName))
        {
            dicPanel[panelName].DeInit();
            //���ٳ����е���Ϸ����
            Destroy(dicPanel[panelName].gameObject);
            //�����ڴ��е�����
            dicPanel.Remove(panelName);
        }
    }
    /// <summary>
    /// �ر����е����
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
