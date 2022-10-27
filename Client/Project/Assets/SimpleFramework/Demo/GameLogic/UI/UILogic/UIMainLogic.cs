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
        //初始化UIBase中层级和类型字段
        uiLayer = UILayer.Default;
        uiType = UIType.UIMain;
    }

    ////打开界面按钮，公有字段，inspector界面赋值
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
        //在实际开发中，整个游戏的红点树要在游戏初始化时全部构建出来
        //声明mail1根节点，它的主key是mail1，无subKey，无父节点，红点类型是随着子节点变化
        RedPointMgr.instance.Add(mail1, null, null, RedPointType.Enternal);
        //声明mail2节点，它的主key是mail1，subKey是mail2，父节点是mail1，红点类型是随着子节点变化
        RedPointMgr.instance.Add(mail1, mail2, mail1, RedPointType.Enternal);
        //声明mail3节点，它的主key是mail1，subKey是mail3，父节点是mail2，红点类型是随着子节点变化
        RedPointMgr.instance.Add(mail1, mail3, mail2, RedPointType.Enternal);
        //声明mai4节点，它的主key是mail1，subKey是mail4，父节点是mail3，红点类型是点击即消失
        RedPointMgr.instance.Add(mail1, mail4, mail3, RedPointType.Once);
        //声明mai5节点，它的主key是mail1，subKey是mail5，父节点是mail3，红点类型是点击即消失
        RedPointMgr.instance.Add(mail1, mail5, mail3, RedPointType.Once);
        //声明mai5节点，它的主key是mail1，subKey是mail6，父节点是mail3，红点类型是点击即消失
        RedPointMgr.instance.Add(mail1, mail6, mail3, RedPointType.Once);

        //在实际开发中，初始化代码要写在对应UI界面的初始化函数中
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
        //Debug.Log("打开Mian");
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
        //    Debug.Log("等待5秒后回调此内容");
        //    Main.ObjectPoolManager.Remove(gameObject);
        //    Debug.Log("回收");

        //});

        //Debug.LogFormat("item[1].name:{0}", TableManager.Tables.TbItem.Get(10000).Name);

        //TableManager.Tables.TranslateText((key, text) => text + "# translate");
        //WaitTimeScript.CancelWait(ref coroutine);

        ////封装的按钮添加事件方法，点击打开或关闭
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
        //取消下面注释，打开新界面时，主界面按钮会失效
        //ChangeBtnState(false);
    }

    public override void OnResume()
    {
        //ChangeBtnState(true);
    }

    public override void OnExit()
    {
    }

    //按钮失效代码
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
