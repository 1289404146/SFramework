using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitTimeScript
{
    private static TaskBehaviour m_Task;
    static WaitTimeScript()
    {
        GameObject go = new GameObject("#WaitTimeManager#");
        GameObject.DontDestroyOnLoad(go);
        m_Task = go.AddComponent<TaskBehaviour>();
    }
    //等待XX时后回调
    public static  Coroutine WaitTime(float time, UnityAction callback)
    {
        return m_Task.StartCoroutine(Coroutine(time, callback));
    }
    //取消等待
    public static  void CancelWait(ref Coroutine coroutine)
    {
        if (coroutine != null)
        {
            m_Task.StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    static IEnumerator Coroutine(float time, UnityAction callback)
    {
        yield return new WaitForSeconds(time);
        if (callback != null)
        {
            callback();
        }
    }
    class TaskBehaviour : MonoBehaviour { }

    //开启定时

    //等待过程中取消
}

