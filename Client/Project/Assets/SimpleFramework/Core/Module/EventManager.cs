using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : BaseMono,IManager
{
    /// <summary>
    /// �¼��������ֵ�
    /// </summary>
    private Dictionary<string, Dictionary<string, UnityAction<object>>> _eventCenterDic =
        new Dictionary<string, Dictionary<string, UnityAction<object>>>();
    /// <summary>
    /// �����Ӧ��/�����ߣ�����ί�в������������Ӧ��/�����ߵ���Ӧ�¼�
    /// </summary>
    /// <param name="actionName">action�¼�������</param>
    /// <param name="eventName">�¼�����</param>
    /// <param name="delegation">��Ӧ����</param>
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
    /// �Ƴ���Ӧ��
    /// </summary>
    /// <param name="actionName">action�¼�������</param>
    /// <param name="eventName">�¼�����</param>
    /// <param name="delegation">��Ӧ����</param>
    public void RemoveListener(string actionName, string eventName, UnityAction<object> delegation)
    {
        if (_eventCenterDic.ContainsKey(actionName) &&
            _eventCenterDic[actionName].ContainsKey(eventName))
        {
            _eventCenterDic[actionName][eventName] -= delegation;
        }
    }
    /// <summary>
    /// �¼�������������action�¼����е��¼���������
    /// </summary>
    /// <param name="actionName">action�¼�������</param>
    /// <param name="eventName">�¼���������</param>
    /// <param name="param">��Ӧ�¼���Ҫ�Ĳ���������Ϊ��</param>
    public void EventTrigger(string actionName, string eventName, [CanBeNull] object param)
    {
        _eventCenterDic[actionName][eventName].Invoke(param);
    }
    /// <summary>
    /// ����ֵ�
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
