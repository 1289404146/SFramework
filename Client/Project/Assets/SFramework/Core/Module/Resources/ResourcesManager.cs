using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourcesManager : BaseMono,IManager
{
    //public T Load<T>(string name) where T :Object
    //{
    //    T go = Resources.Load<T>(name);
    //    return go;
    //}

    public void Initilize()
    {
        cacheDic = new Dictionary<string, object>();
    }

    public void DeInitilize()
    {
        cacheDic.Clear();
        cacheDic = null;
    }

    //缓存已经加载的资源
    private static Dictionary<string, object> cacheDic;
    /// <summary>
    /// 同步加载资源
    /// </summary>
    /// <typeparam name="T">加载资源类型</typeparam>
    /// <param name="resourceName">资源名称</param>
    /// <returns></returns>
    public T Load<T>(string resourceName) where T : Object
    {
            if (!cacheDic.ContainsKey(resourceName))
            {
                T res = Resources.Load<T>(resourceName);
                cacheDic.Add(resourceName, res);
            }
            return cacheDic[resourceName] as T;
    }


    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="resourceName"></param>
    /// <param name="action"></param>
    public void LoadAsync<T>(string resourceName, UnityAction<T> action = null) where T : Object
    {
        StartCoroutine(LoadAsyncCore<T>(resourceName, action));
    }
    private IEnumerator LoadAsyncCore<T>(string resourceName, UnityAction<T> action) where T : Object
    {
            if (!cacheDic.ContainsKey(resourceName))
            {
                ResourceRequest request = Resources.LoadAsync<T>(resourceName);
                yield return request;
                //由于采用异步协程，需要二重判断
                if (!cacheDic.ContainsKey(resourceName))
                    cacheDic.Add(resourceName, request.asset as T);
            }
            action?.Invoke(cacheDic[resourceName] as T);
    }
}

