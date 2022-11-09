using DCET.Hotfix;
using DCET.Runtime;
using FairyGUI;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FUIInfo
{
    private string _packName;
    private string _dialogName;

    public FUIInfo(string packName, string dialogName)
    {
        _packName = packName;
        _dialogName = dialogName;
    }

    public string GetFUIPackageName()
    {
        return _packName;
    }

    public string GetFUIName()
    {
        return _dialogName;
    }
}
/// <summary>
/// 管理所有顶层UI, 顶层UI都是GRoot的孩子
/// </summary>
public class FUIManager : BaseMono, IManager
{
    private Dictionary<string, BaseFUI> fuiBaseDict = new Dictionary<string, BaseFUI>();
    private Dictionary<string, FUIInfo> fuiInfoDict = new Dictionary<string, FUIInfo>();
    //所有UI面板perfab的路径key：UIType——value：Resources下的路径
    public Dictionary<string, GComponent> dicPath;
    //根据上面路径，加载的好的具体的UI面板类
    public Dictionary<string, BaseFUI> dicPanel;
    //栈存储所有打开的UI面板,打开UI，push栈，关闭UI，pop栈
    private Stack<BaseFUI> panelStack;
    public void Initilize()
    {
        GRoot.inst.SetContentScaleFactor(1920, 1080);
        RuntimeBinder.BindAll();
        HotfixBinder.BindAll();
    }
    /// <summary>
    /// 打开面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T OpenPanel<T>() where T : BaseFUI,new()
    {
        string panelName = typeof(T).Name;
        if (fuiBaseDict.ContainsKey(panelName))
        {
            return fuiBaseDict[panelName] as T;
        }
        T panel = new T();
        panel.OnEnter();
        fuiBaseDict.Add(panelName, panel);
        return panel;
    }
    /// <summary>
    /// 获取面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T GetPanel<T>() where T : BaseFUI
    {
        string panelName = typeof(T).Name;
        if (fuiBaseDict.ContainsKey(panelName))
        {
            return fuiBaseDict[panelName] as T;
        }
        return null;
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void ClosePanel<T>()
    {
        string panelName = typeof(T).Name;
        if (fuiBaseDict.ContainsKey(panelName))
        {
            //销毁场景中的游戏对象
            fuiBaseDict[panelName].OnExit();
            //销毁内存中的引用
            fuiBaseDict.Remove(panelName);
        }
    }
    /// <summary>
    /// 关闭所有的面板
    /// </summary>
    public void CloseAll()
    {
        foreach (var item in fuiBaseDict)
        {
            fuiBaseDict[item.Key].OnExit();
        }
        fuiBaseDict.Clear();
    }


    public void DeInitilize()
    {
        Debug.Log("FUIManager------DeInitilize");
    }
}

