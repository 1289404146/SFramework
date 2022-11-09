using DCET.Hotfix;
using FairyGUI;
using Google.Protobuf;
using Person;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Transform Global { get; set; }
    public Transform Unit { get; set; }
    public Transform UI { get; set; }
    public static UIManager UIManager
    {
        set;
        get;
    }
    public static AudioManager AudioManager
    {
        set;
        get;
    }
    public static ConfigManager ConfigManager
    {
        set;
        get;
    }
    public static EventManager EventManager
    {
        set;
        get;
    }
    public static ScenesManager ScenesManager
    {
        set;
        get;
    }
    public static ResourcesManager ResourcesManager
    {
        set;
        get;
    }
    public static LocalizationManager LocalizationManager
    {
        set;
        get;
    }
    public static ClientManager ClientManager
    {
        set;
        get;
    }
    public static ObjectPoolManager ObjectPoolManager
    {
        set;
        get;
    }
    public static GameManager GameManager
    {
        set;
        get;
    }
    public static AssetBundleManager AssetBundleManager
    {
        set;
        get;
    }
    public static FUIPackageManager FUIPackageManager
    {
        set;
        get;
    }
    public static FUIManager FUIManager
    {
        set;
        get;
    }
    public static RequestManager RequestManager
    {
        set;
        get;
    }
    private static EventSystem eventSystem;
    public static EventSystem EventSystem
    {
        get
        {
            return eventSystem ?? (eventSystem = new EventSystem());
        }
    }

    private void Awake()
    {
        string[] ips = NetHelper.GetAddressIPs();
        for (int i = 0; i < ips.Length; i++)
        {
            Log.GreenDebug($"ips={ips[i]}" + "-----" + i); //$"<color=#E4C93D>{tips}</color>";
        }
        long lo = RandomHelper.RandInt64();//-5650151388555438852
        ulong ulo = RandomHelper.RandUInt64();//1821685413296944572
        int run = RandomHelper.RandomNumber(12, 100);
        Log.RedDebug(lo.ToString());
        Log.RedDebug(ulo.ToString());
        Log.RedDebug(run.ToString());

        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        Global = GameObject.Find("Init").transform;
        //Unit = GameObject.Find("/Global/Unit").transform;
        UI = GameObject.Find("Init/UI").transform;
    }
    private void Start()
    {
        AddDefaultManager();
        Initilize();
        Test();
        Main.EventSystem.Run(EventIdType.UpdateCompetitions);
        //GameManager.SwitchGameState(GameState.Init);
        //GameManager.SwitchGameState(GameState.start);
        //GameManager.SwitchGameState(GameState.gameing);
        //GameManager.SwitchGameState(GameState.end);
        //GameManager.SwitchGameState(GameState.DeInit);
        Main.ScenesManager.LoadScene(SceneType.Empty);
        AttackRequest attackRequest = new AttackRequest(RequestCode.Game, ActionCode.Attack, (data) =>
            {
                Debug.Log(data);
            });
        Main.RequestManager.AddRequest(ActionCode.Attack, attackRequest);
        //Main.ClientManager.SendRequest(RequestCode.Game, ActionCode.Attack, 46.ToString());
        ////Debug.Log("send 46");
    }

    private void Test()
    {
        Main.RequestManager.AddRequest(ActionCode.TestFun, new TestRequest(RequestCode.Test, ActionCode.TestFun, (data) =>
          {
              Debug.Log(data);
              IMessage message = new OnePerson();
              OnePerson mySelf = new OnePerson();
              mySelf = (OnePerson)message.Descriptor.Parser.ParseFrom(data);
              //打印输出
              Debug.Log($"My name is:{mySelf.Name}");
              Debug.Log($"My idNumber is:{mySelf.IdNumber}");
              Debug.Log($"My gender is:{mySelf.Gender}");
              Debug.Log($"My profession is:{mySelf.Profession}");
              //if ((ReturnCode)data == ReturnCode.Success)
              //{ }
          }));
        //创建OnePerson对象并初始化
        OnePerson onePerson = new OnePerson();
        onePerson.Name = "张三";
        onePerson.IdNumber = 000001;
        onePerson.Gender = genders.Man;
        onePerson.Profession = "法外狂徒";
        //将onePerson对象转换为字节数组
        byte[] dataByte = onePerson.ToByteArray();
        //Main.ClientManager.SendRequest(RequestCode.Test, ActionCode.TestFun, dataByte);

        //...
        //将字节数组转换为OnePerson对象
        IMessage message = new OnePerson();
        OnePerson mySelf = new OnePerson();
        mySelf = (OnePerson)message.Descriptor.Parser.ParseFrom(dataByte);
        //打印输出
        //Debug.Log($"My name is:{mySelf.Name}");
        //Debug.Log($"My idNumber is:{mySelf.IdNumber}");
        //Debug.Log($"My gender is:{mySelf.Gender}");
        //Debug.Log($"My profession is:{mySelf.Profession}");

    }

    private void AddDefaultManager()
    {
        RequestManager = gameObject.AddComponent<RequestManager>();
        ResourcesManager = gameObject.AddComponent<ResourcesManager>();
        AssetBundleManager = gameObject.AddComponent<AssetBundleManager>();
        LocalizationManager = gameObject.AddComponent<LocalizationManager>();
        ClientManager = gameObject.AddComponent<ClientManager>();
        UIManager = gameObject.AddComponent<UIManager>();
        AudioManager = gameObject.AddComponent<AudioManager>();
        ConfigManager = gameObject.AddComponent<ConfigManager>();
        EventManager = gameObject.AddComponent<EventManager>();
        ScenesManager = gameObject.AddComponent<ScenesManager>();
        GameManager = gameObject.AddComponent<GameManager>();
        ObjectPoolManager = gameObject.AddComponent<ObjectPoolManager>();
        //FUIPackageManager = gameObject.AddComponent<FUIPackageManager>();
        //FUIManager = gameObject.AddComponent<FUIManager>();
    }
    private void Initilize()
    {
        RequestManager.Initilize();
        UIManager.Initilize();
        AudioManager.Initilize();
        ConfigManager.Initilize();
        EventManager.Initilize();
        ScenesManager.Initilize();
        ResourcesManager.Initilize();
        LocalizationManager.Initilize();
        ClientManager.Initilize();
        ObjectPoolManager.Initilize();
        //FUIPackageManager.Initilize();
        //FUIManager.Initilize();
    }

    public T AddComponentToMain<T>() where T : MonoBehaviour
    {
        T t;
        if (gameObject.GetComponent<T>() == null)
        {
            t = gameObject.AddComponent<T>();
            return t;
        }
        else
        {
            t = gameObject.GetComponent<T>();
            return t;
        }
    }
    public void RemoveComponentFromMain<T>() where T : MonoBehaviour
    {
        T t = gameObject.GetComponent<T>();
        if (t != null)
        {
            Destroy(t);
        }
    }
    private void OnDestroy()
    {
        eventSystem = null;
        RequestManager.DeInitilize();
        //FUIManager.DeInitilize();
        //FUIPackageManager.DeInitilize();
        ClientManager.DeInitilize();
        LocalizationManager.DeInitilize();
        ResourcesManager.DeInitilize();
        ScenesManager.DeInitilize();
        EventManager.DeInitilize();
        ConfigManager.DeInitilize();
        AudioManager.DeInitilize();
        UIManager.DeInitilize();
    }
}
