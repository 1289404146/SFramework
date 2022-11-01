using DCET.Hotfix;
using FairyGUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Main : MonoBehaviour
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
    public static NetworkManager NetworkManager
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


    private void Awake()
    {
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

        //GameManager.SwitchGameState(GameState.Init);
        //GameManager.SwitchGameState(GameState.start);
        //GameManager.SwitchGameState(GameState.gameing);
        //GameManager.SwitchGameState(GameState.end);
        //GameManager.SwitchGameState(GameState.DeInit);
        Main.ScenesManager.LoadScene(SceneType.Empty);
    }
    private void Initilize()
    {
        UIManager.Initilize();
        AudioManager.Initilize();
        ConfigManager.Initilize();
        EventManager.Initilize();
        ScenesManager.Initilize();
        ResourcesManager.Initilize();
        LocalizationManager.Initilize();
        NetworkManager.Initilize();
        ObjectPoolManager.Initilize();
        FUIPackageManager.Initilize();
        FUIManager.Initilize();

    }
    private void AddDefaultManager()
    {
        ResourcesManager = gameObject.AddComponent<ResourcesManager>();
        AssetBundleManager = gameObject.AddComponent<AssetBundleManager>();
        LocalizationManager = gameObject.AddComponent<LocalizationManager>();
        NetworkManager = gameObject.AddComponent<NetworkManager>();
        UIManager = gameObject.AddComponent<UIManager>();
        AudioManager = gameObject.AddComponent<AudioManager>();
        ConfigManager = gameObject.AddComponent<ConfigManager>();
        EventManager = gameObject.AddComponent<EventManager>();
        ScenesManager = gameObject.AddComponent<ScenesManager>();
        GameManager = gameObject.AddComponent<GameManager>();
        ObjectPoolManager = gameObject.AddComponent<ObjectPoolManager>();
        FUIPackageManager = gameObject.AddComponent<FUIPackageManager>();
        FUIManager = gameObject.AddComponent<FUIManager>();
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
       T t= gameObject.GetComponent<T>();
        if (t != null)
        {
            Destroy(t);
        }
    }
    private void OnDestroy()
    {
        FUIManager.DeInitilize();
        FUIPackageManager.DeInitilize();
        NetworkManager.DeInitilize();
        LocalizationManager.DeInitilize();
        ResourcesManager.DeInitilize();
        ScenesManager.DeInitilize();
        EventManager.DeInitilize();
        ConfigManager.DeInitilize();
        AudioManager.DeInitilize();
        UIManager.DeInitilize();
    }
}
