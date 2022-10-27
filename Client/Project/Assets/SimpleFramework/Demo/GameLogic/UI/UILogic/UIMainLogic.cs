using GameLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainLogic : UIBaseLogic
{
    UIMainLogic()
    {
        //��ʼ��UIBase�в㼶�������ֶ�
        uiLayer = UILayer.Default;
        uiType = UIType.UIMain;
    }

    ////�򿪽��水ť�������ֶΣ�inspector���渳ֵ
    //public Button btnInventory;
    //public Button btnShop;
    //public Button btnSkill;
    //public Button btnQuest;
    //public Button btnEquipment;

    public UIMainView uiView;

    public int count1 = 5;
    public int count2 = 6;
    public int count3 = 7;

    string mail1 = "mail1";
    string mail2 = "mail2";
    string mail3 = "mail3";
    string mail4 = "mail4";
    string mail5 = "mail5";
    string mail6 = "mail6";
    public override void OnEnter()
    {
        base.OnEnter();
        uiView = new UIMainView();
        uiView.Init(transform);
        //��ʵ�ʿ����У�������Ϸ�ĺ����Ҫ����Ϸ��ʼ��ʱȫ����������
        //����mail1���ڵ㣬������key��mail1����subKey���޸��ڵ㣬��������������ӽڵ�仯
        RedPointMgr.instance.Add(mail1, null, null, RedPointType.Enternal);
        //����mail2�ڵ㣬������key��mail1��subKey��mail2�����ڵ���mail1����������������ӽڵ�仯
        RedPointMgr.instance.Add(mail1, mail2, mail1, RedPointType.Enternal);
        //����mail3�ڵ㣬������key��mail1��subKey��mail3�����ڵ���mail2����������������ӽڵ�仯
        RedPointMgr.instance.Add(mail1, mail3, mail2, RedPointType.Enternal);
        //����mai4�ڵ㣬������key��mail1��subKey��mail4�����ڵ���mail3����������ǵ������ʧ
        RedPointMgr.instance.Add(mail1, mail4, mail3, RedPointType.Once);
        //����mai5�ڵ㣬������key��mail1��subKey��mail5�����ڵ���mail3����������ǵ������ʧ
        RedPointMgr.instance.Add(mail1, mail5, mail3, RedPointType.Once);
        //����mai5�ڵ㣬������key��mail1��subKey��mail6�����ڵ���mail3����������ǵ������ʧ
        RedPointMgr.instance.Add(mail1, mail6, mail3, RedPointType.Once);

        //��ʵ�ʿ����У���ʼ������Ҫд�ڶ�ӦUI����ĳ�ʼ��������
        RedPointMgr.instance.Init(mail1, mail1, OnMail1Show);
        RedPointMgr.instance.Init(mail1, mail2, OnMail2Show);
        RedPointMgr.instance.Init(mail1, mail3, OnMail3Show);
        RedPointMgr.instance.Init(mail1, mail4, OnMail4Show, uiView.mail4Btn);
        RedPointMgr.instance.Init(mail1, mail5, OnMail5Show, uiView.mail5Btn);
        RedPointMgr.instance.Init(mail1, mail6, OnMail6Show, uiView.mail6Btn);

        uiView.btnSet1.onClick.AddListener(OnBtnSet1Click);
        uiView.btnSet2.onClick.AddListener(OnBtnSet2Click);
        uiView.btnSet3.onClick.AddListener(OnBtnSet3Click);
        //Main.EventManager.AddListener("action","1", Delegatedtest);
        //Main.EventManager.AddListener("action", "2", Delegatedtest);
        //Main.EventManager.AddListener("action", "3", Delegatedtest);


        //Main.AudioManager.PlayBgm("chongci2");
        //Main.AudioManager.PlayEffect("Countdown",true,0.2f);


        //Main.LocalizationManager.LanguageState = Language.Chinese;

        //StartCoroutine(init());
        //Main.EventManager.EventTrigger("action", "1", "1");
        //Main.EventManager.EventTrigger("action", "2", "2");
        //Main.EventManager.EventTrigger("action", "3", "3");
        //List<string> s = Main.ConfigManager.ConfigContent.players[10000];
        //Player player = new Player();
        //player.name = s[0];
        //player.age = int.Parse(s[1]);
        //Debug.Log(player.name+player.age);
        //Debug.Log("��Mian");
        //UnityEngine.Object aaa=  Main.AssetBundleManager.LoadRes("cube.unity3d", "Cube");
        //Debug.Log(aaa.name);
        //GameObject sss = Main.ResourcesManager.Load<GameObject>("Prefabs/Cube");
        //Debug.Log(sss.name);
        //GameObject game= Instantiate(sss);
        //Debug.Log(game.name);
        //Main.ResourcesManager.LoadAsync<GameObject>("Prefabs/Sphere",(go)=>
        //{
        //    Instantiate(go);
        //    Debug.Log(go.name);
        //});

        //Main.ScenesManager.Initilize();
        //Main.ScenesManager.DeInitilize();
        //Dictionary<int,List<string>> dic = Main.ConfigManager.ConfigContent.players;
        //player.name =dic[10001][0];
        //player.age =int.Parse( dic[10001][1]);
        //Debug.Log(player.name + player.age);
        //GameObject gameObject= Main.ObjectPoolManager.Get();
        //Debug.Log(gameObject.name);
        //Coroutine coroutine = WaitTimeScript.WaitTime(5f, delegate
        //{
        //    Debug.Log("�ȴ�5���ص�������");
        //    Main.ObjectPoolManager.Remove(gameObject);
        //    Debug.Log("����");

        //});

        //Debug.LogFormat("item[1].name:{0}", TableManager.Tables.TbItem.Get(10000).Name);

        //TableManager.Tables.TranslateText((key, text) => text + "# translate");
        //WaitTimeScript.CancelWait(ref coroutine);

        ////��װ�İ�ť����¼�����������򿪻�ر�
        //AddBtnListener(btnEquipment, UIType.UIEquipment);
        //AddBtnListener(btnShop, UIType.UIShop);
        //AddBtnListener(btnSkill, UIType.UISkill);
        //AddBtnListener(btnQuest, UIType.UIQuest);
        //AddBtnListener(btnInventory, UIType.UIInventory);
    }

    private void Delegatedtest(object arg0)
    {
        Debug.Log(arg0.ToString());
    }


    IEnumerator init()
    {
        yield return new WaitForSeconds(3.2f);

    }
    //private void AddBtnListener(Button go, string type)
    //{
    //    go.onClick.AddListener(() =>
    //    {
    //        if (Main.UIManager.GetTopPanel().uiType == type)
    //            Main.UIManager.PopPanel();
    //        else
    //            Main.UIManager.PushPanel(type);
    //    });
    //}

    public override void OnPause()
    {
        //ȡ������ע�ͣ����½���ʱ�������水ť��ʧЧ
        //ChangeBtnState(false);
    }

    public override void OnResume()
    {
        //ChangeBtnState(true);
    }

    public override void OnExit()
    {
    }

    //��ťʧЧ����
    public void ChangeBtnState(bool value)
    {
        //btnInventory.enabled = value;
        //btnShop.enabled = value;
        //btnSkill.enabled = value;
        //btnQuest.enabled = value;
        //btnEquipment.enabled = value;
    }

    private void OnMail1Show(RedPointState state, int data)
    {
        uiView.mail1RedPoint.SetActive(state == RedPointState.Show);
        uiView.txtMail1.text = data.ToString();
    }

    private void OnMail2Show(RedPointState state, int data)
    {
        uiView.mail2RedPoint.SetActive(state == RedPointState.Show);
        uiView.txtMail2.text = data.ToString();
    }

    private void OnMail3Show(RedPointState state, int data)
    {
        uiView.mail3RedPoint.SetActive(state == RedPointState.Show);
        uiView.txtMail3.text = data.ToString();
    }

    private void OnMail4Show(RedPointState state, int data)
    {
        uiView.mail4RedPoint.SetActive(state == RedPointState.Show);
        uiView.txtMail4.text = data.ToString();
    }

    private void OnMail5Show(RedPointState state, int data)
    {
        uiView.mail5RedPoint.SetActive(state == RedPointState.Show);
        uiView.txtMail5.text = data.ToString();

    }

    private void OnMail6Show(RedPointState state, int data)
    {
        uiView.mail6RedPoint.SetActive(state == RedPointState.Show);
        uiView.txtMail6.text = data.ToString();
    }

    private void OnBtnSet1Click()
    {
        RedPointMgr.instance.SetState(mail1, mail4, count1 == 0 ? RedPointState.Hide : RedPointState.Show, count1);
    }

    private void OnBtnSet2Click()
    {
        RedPointMgr.instance.SetState(mail1, mail5, count2 == 0 ? RedPointState.Hide : RedPointState.Show, count2);
    }

    private void OnBtnSet3Click()
    {
        RedPointMgr.instance.SetState(mail1, mail6, count3 == 0 ? RedPointState.Hide : RedPointState.Show, count3);
    }
}
