using GameLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanMain : UIBase
{
    PanMain()
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
    Text sText;
    Text sText1;
    Button Button;

    public override void OnEnter()
    {
        base.OnEnter();
        Main.EventManager.AddListener("action","1", Delegatedtest);
        Main.EventManager.AddListener("action", "2", Delegatedtest);
        Main.EventManager.AddListener("action", "3", Delegatedtest);


        Main.AudioManager.PlayBgm("chongci2");
        Main.AudioManager.PlayEffect("Countdown",true,0.2f);
        sText= transform.Find("Toggle/Label").GetComponent<Text>();
        sText1 = transform.Find("Text").GetComponent<Text>();
        Button = transform.Find("Button").GetComponent<Button>();
        Button.onClick.AddListener(() =>
        {
            List<int> vs = new List<int>();
            vs.Add(1);
            vs.Add(1);
            vs.Add(1);
            vs.Add(1);
            Main.NetworkManager.Send(vs.ToString());
        });
        Main.LocalizationManager.LanguageState = Language.Chinese;
        sText.text = Main.LocalizationManager.GetValue(10000);
        sText1.text = Main.LocalizationManager.GetLanguageByID(50000);
        StartCoroutine(init());
        Main.EventManager.EventTrigger("action", "1", "1");
        Main.EventManager.EventTrigger("action", "2", "2");
        Main.EventManager.EventTrigger("action", "3", "3");
        List<string> s = Main.ConfigManager.ConfigContent.players[10000];
        Player player = new Player();
        player.name = s[0];
        player.age = int.Parse(s[1]);
        Debug.Log(player.name+player.age);
        Debug.Log("��Mian");
        Main.SceneManager.Initilize();
        Main.SceneManager.DeInitilize();
        Dictionary<int,List<string>> dic = Main.ConfigManager.ConfigContent.players;
        player.name =dic[10001][0];
        player.age =int.Parse( dic[10001][1]);
        Debug.Log(player.name + player.age);
        GameObject gameObject= Main.ObjectPoolManager.Get();
        Debug.Log(gameObject.name);
        Coroutine coroutine = WaitTimeScript.WaitTime(5f, delegate
        {
            Debug.Log("�ȴ�5���ص�������");
            Main.ObjectPoolManager.Remove(gameObject);
            Debug.Log("����");

        });

        Debug.LogFormat("item[1].name:{0}", TableManager.Tables.TbItem.Get(10000).Name);

        TableManager.Tables.TranslateText((key, text) => text + "# translate");
        WaitTimeScript.CancelWait(ref coroutine);

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
        sText.text = Main.LocalizationManager.GetValue(10001);
        yield return new WaitForSeconds(3.2f);
        Main.LocalizationManager.InitLocalizationManager("English");
        sText.text = Main.LocalizationManager.GetValue(10000);
        yield return new WaitForSeconds(3.2f);
        Main.LocalizationManager.LanguageState = Language.English;
        sText1.text = Main.LocalizationManager.GetLanguageByID(50000);
        yield return new WaitForSeconds(3.2f);
        Main.LocalizationManager.LanguageState = Language.Japanese;
        sText1.text = Main.LocalizationManager.GetLanguageByID(50000);
        yield return new WaitForSeconds(3.2f);
        Main.LocalizationManager.LanguageState = Language.Korean;
        sText1.text = Main.LocalizationManager.GetLanguageByID(50000);
        sText1.text =TimerTools.UnixToDateTime(TimerTools.GetNowTime());
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
}
