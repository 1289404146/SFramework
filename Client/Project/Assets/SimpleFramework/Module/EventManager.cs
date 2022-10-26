using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : BaseMono,IManager
{
    /// <summary>
    /// 事件中心类字典
    /// </summary>
    private Dictionary<string, Dictionary<string, UnityAction<object>>> _eventCenterDic =
        new Dictionary<string, Dictionary<string, UnityAction<object>>>();
    /// <summary>
    /// 添加响应者/监听者，其中委托参数传入的市响应者/监听者的响应事件
    /// </summary>
    /// <param name="actionName">action事件集名称</param>
    /// <param name="eventName">事件名称</param>
    /// <param name="delegation">响应函数</param>
    public void AddListener(string actionName, string eventName, UnityAction<object> delegation)
    {
        if (!_eventCenterDic.ContainsKey(actionName))
        {
            _eventCenterDic.Add(actionName, new Dictionary<string, UnityAction<object>>());
        }
        if (_eventCenterDic[actionName].ContainsKey(eventName))
        {
            _eventCenterDic[actionName][eventName] += delegation;
        }
        else
        {
            _eventCenterDic[actionName].Add(eventName, delegation);
        }
    }
    /// <summary>
    /// 移除响应者
    /// </summary>
    /// <param name="actionName">action事件集名称</param>
    /// <param name="eventName">事件名称</param>
    /// <param name="delegation">响应函数</param>
    public void RemoveListener(string actionName, string eventName, UnityAction<object> delegation)
    {
        if (_eventCenterDic.ContainsKey(actionName) &&
            _eventCenterDic[actionName].ContainsKey(eventName))
        {
            _eventCenterDic[actionName][eventName] -= delegation;
        }
    }
    /// <summary>
    /// 事件触发方法，由action事件集中的事件方法调用
    /// </summary>
    /// <param name="actionName">action事件集名称</param>
    /// <param name="eventName">事件方法名称</param>
    /// <param name="param">响应事件需要的参数，可以为空</param>
    public void EventTrigger(string actionName, string eventName, [CanBeNull] object param)
    {
        _eventCenterDic[actionName][eventName].Invoke(param);
    }
    /// <summary>
    /// 清空字典
    /// </summary>
    public void Clear()
    {
        _eventCenterDic.Clear();
    }
    public void OnDestroy()
    {
        Clear();
    }

    public void Initilize()
    {
        Debug.Log("EventManager------Initilize");

    }

    public void DeInitilize()
    {
        Debug.Log("EventManager------DeInitilize");
    }
}
