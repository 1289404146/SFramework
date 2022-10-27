using UnityEngine;
using System.Collections;
using FairyGUI;

public class BaseFUI
{
    protected GComponent _view;
    protected string _dialogType;

    public BaseFUI()
    {

    }

    public  void SetDialogView(GComponent view)
    {
        _view = view;
    }

    public GComponent GetView()
    {
        return _view;
    }

    /// <summary>
    /// 创建前期 主要用于寻找view上的组件
    /// </summary>
    public virtual void OnBeforeCreate()
    {

    }

    /// <summary>
    /// 添加监听事件
    /// </summary>
    public virtual void AddListener()
    {

    }

    /// <summary>
    /// 删除添加事件
    /// </summary>
    public virtual void RemoveListener()
    {

    }

    /// <summary>
    /// 创建成功 主要用于逻辑注册
    /// </summary>
    public virtual void OnCreate()
    {

    }

    /// <summary>
    /// 用于缓存界面后的第二次以上打开
    /// </summary>
    public virtual void OnRefresh()
    {

    }

    /// <summary>
    /// 界面隐藏
    /// </summary>
    public virtual void OnHide()
    {

    }

    /// <summary>
    /// 界面销毁
    /// </summary>
    public virtual void OnDestory()
    {

    }

}