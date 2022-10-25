using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBase,IManager
{
    //����UI���perfab��·��key��UIType����value��Resources�µ�·��
    public Dictionary<string, string> dicPath;
    //��������·�������صĺõľ����UI�����
    public Dictionary<string, UIBase> dicPanel;
    //ջ�洢���д򿪵�UI���,��UI��pushջ���ر�UI��popջ
    private Stack<UIBase> panelStack;
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

    //��ȡdicPanel�д洢�Ļ���UIBase���࣬���Ϊ�գ��ȼ�����ӽ�ȥ
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

    //��UI����
    public void PushPanel(string panelType)
    {
        if (panelStack == null)
        {
            panelStack = new Stack<UIBase>();
        }

        //ֹͣ��һ������
        if (panelStack.Count > 0)
        {
            UIBase top = panelStack.Peek();
            top.OnPause();
        }

        UIBase panel = GetPanel(panelType);
        panelStack.Push(panel);
        panel.OnEnter();
    }

    //�ر����ϲ����
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

        //�˳�ջ�����
        UIBase top = panelStack.Pop();
        top.OnExit();

        //�ָ���һ�����
        if (panelStack.Count > 0)
        {
            UIBase panel = panelStack.Peek();
            panel.OnResume();
        }
    }

    //��ȡ���ϲ����
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
