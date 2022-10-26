using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Main : MonoBehaviour
{

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
    public static SceneManager SceneManager
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

    }
    private void Start()
    {
        AddDefaultManager();
        Initilize();
        UIManager.PushPanel(UIType.UILogin);
        GameManager.SwitchGameState(GameState.Init);
        GameManager.SwitchGameState(GameState.start);
        GameManager.SwitchGameState(GameState.gameing);
        GameManager.SwitchGameState(GameState.end);
        GameManager.SwitchGameState(GameState.DeInit);

    }
    public void Initilize()
    {
        UIManager.Initilize();
        AudioManager.Initilize();
        ConfigManager.Initilize();
        EventManager.Initilize();
        SceneManager.Initilize();
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
        SceneManager = gameObject.AddComponent<SceneManager>();
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
        UIManager.DeInitilize();
        AudioManager.DeInitilize();
        ConfigManager.DeInitilize();
        EventManager.DeInitilize();
        SceneManager.DeInitilize();
        ResourcesManager.DeInitilize();
        LocalizationManager.DeInitilize();
        NetworkManager.DeInitilize();
        ObjectPoolManager.DeInitilize();
    }
}
