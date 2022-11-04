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

    //��UI����
    public void PushPanel<T>(string panelType)where T: UIBaseLogic
    {
        if (panelStack == null)
        {
            panelStack = new Stack<UIBaseLogic>();
        }

        //ֹͣ��һ������
        if (panelStack.Count > 0)
        {
            UIBaseLogic top = panelStack.Peek();
            top.OnPause();
        }

        UIBaseLogic panel = GetPanel<T>(panelType);
        panelStack.Push(panel);
        panel.OnEnter();
    }

    //�ر����ϲ����
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

        //�˳�ջ�����
        UIBaseLogic top = panelStack.Pop();
        top.OnExit();

        //�ָ���һ�����
        if (panelStack.Count > 0)
        {
            UIBaseLogic panel = panelStack.Peek();
            panel.OnResume();
        }
    }

    //��ȡ���ϲ����
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
