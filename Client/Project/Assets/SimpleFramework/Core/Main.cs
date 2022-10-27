using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Main : MonoBehaviour
{
    public static GameObject mainObj;
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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        mainObj = gameObject;
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
    public void Initilize()
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
    }
    public void AddDefaultManager()
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

    }
    public static void  AddComponentToMain<T>() where T : MonoBehaviour
    {

    }
    public static void RemoveComponentFromMain<T>() where T : MonoBehaviour
    {
 
    }
    public void OnDestroy()
    {
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
