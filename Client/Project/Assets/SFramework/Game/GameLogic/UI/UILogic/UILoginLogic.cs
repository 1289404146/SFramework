using Google.Protobuf;
using Person;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILoginLogic : UIBaseLogic
{
    public UILoginView uiView;

    public UILoginLogic()
    {
        uiLayer = UILayer.Default;
        uiType = UIType.UILogin;
    }
    private void Awake()
    {
        //manager = GameObject.Find("NetworkManager").GetComponent<Mirror.NetworkManager>();

        uiView = new UILoginView();
        uiView.Init(transform);
        uiView.login.onClick.AddListener(LoginClick);
        uiView.quit.onClick.AddListener(QuitClick);
        uiView.regist.onClick.AddListener(RegistClick);

    }
    public void Start()
    {
        gameObject.SetActive(true);
        Main.RequestManager.AddRequest(ActionCode.Login, new LoginRequest(RequestCode.User, ActionCode.Login, (data) => {
            string[] strs = data.Split(',');
            ReturnCode returnCode = (ReturnCode)int.Parse(strs[0]);
            if (returnCode == ReturnCode.Success)
            {
                string username = strs[1];
                int totalCount = int.Parse(strs[2]);
                int winCount = int.Parse(strs[3]);
                UserData userData= new UserData(username, totalCount,winCount);
                Main.GameManager.UserData = userData;
                Debug.Log(data);
                Main.UIManager.ClosePanel<UILoginLogic>(UIType.UILogin);
                Main.UIManager.OpenPanel<UIGameMainLogic>(UIType.UIGameMain);
                Main.UIManager.GetPanel<UIGameMainLogic>(UIType.UIGameMain).SetName(Main.GameManager.UserData.Username);
                Main.UIManager.GetPanel<UIGameMainLogic>(UIType.UIGameMain).SetWin(Main.GameManager.UserData.WinCount.ToString());
                Main.UIManager.GetPanel<UIGameMainLogic>(UIType.UIGameMain).SetTotol(Main.GameManager.UserData.TotalCount.ToString());


                //UserData ud = new UserData(username, totalCount, winCount);
                //facade.SetUserData(ud);
            }
            else
            {
                Debug.Log(data);
                Debug.Log("δ�ҵ�");
            }
        }));
    }
    private void RegistClick()
    {
        Main.UIManager.ClosePanel<UIRegistLogic>(UIType.UIRegist);
        Main.UIManager.OpenPanel<UILoginLogic>(UIType.UIRegist);
    }

    private void QuitClick()
    {
    }

    private void LoginClick()
    {
        string msg = "";
        if (string.IsNullOrEmpty(uiView.acount.text))
        {
            msg += "�û�������Ϊ�� ";
        }
        if (string.IsNullOrEmpty(uiView.password.text))
        {
            msg += "���벻��Ϊ�� ";
        }
        if (msg != "")
        {
            Debug.Log(msg);
            return;
        }

        string data = uiView.acount.text + "," + uiView.password.text;
        //����OnePerson���󲢳�ʼ��
        OnePerson onePerson = new OnePerson();
        onePerson.Name = "����";
        onePerson.IdNumber = 000001;
        onePerson.Gender = genders.Man;
        onePerson.Profession = "�����ͽ";
        //��onePerson����ת��Ϊ�ֽ�����
        string dataByte = onePerson.ToString();

        Debug.Log(dataByte);
        Main.ClientManager.SendRequest(RequestCode.User, ActionCode.Login, data);
    }
    [Serializable]
    public class Person 
    {
        public int age ;
    }
}