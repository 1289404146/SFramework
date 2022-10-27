using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RedPointMgr : IDisposable
{
    public static RedPointMgr instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = new RedPointMgr();
            }

            return s_Instance;
        }
    }
    public RedPointMgr()
    {
        m_ListRedPointTrees = new List<RedPoint>();
    }

    public void Add(string key, string subKey, string parentKey, RedPointType type)
    {
        RedPoint root = GetRoot(key);

        if (string.IsNullOrEmpty(subKey) || key.Equals(subKey))
        {
            if (root != null)
            {
                Debug.LogError("The red point root [" + key + "] is already exist!");
                return;
            }

            root = new RedPoint(key, key, true, type);
            m_ListRedPointTrees.Add(root);
        }
        else
        {
            if (root == null)
            {
                Debug.LogError("The red point root [" + key + "] is invalid,please add it first");
                return;
            }

            RedPoint node = new RedPoint(key, subKey, false, type);
            root.AddChild(node, parentKey);
        }
    }

    public void Remove(string key, string subKey)
    {
        if (string.IsNullOrEmpty(subKey) || key.Equals(subKey))
        {
            for (int i = m_ListRedPointTrees.Count - 1; i >= 0; i--)
            {
                if (m_ListRedPointTrees[i].key.Equals(key))
                {
                    m_ListRedPointTrees[i].Dispose();
                    m_ListRedPointTrees.RemoveAt(i);
                    return;
                }
            }

            return;
        }

        RedPoint root = GetRoot(key);

        if (root == null)
        {
            return;
        }

        root.RemoveChild(subKey);
    }

    public void Init(string key, string subKey, Action<RedPointState, int> showEvent, Button btn = null)
    {
        RedPoint root = GetRoot(key);

        if (root == null)
        {
            Debug.LogError("The red point root [" + key + "] is invalid,please add it first");
            return;
        }

        RedPoint node = root.GetChild(subKey);

        if (node == null)
        {
            Debug.LogError("The red point node [" + subKey + "] is invalid,please add it first");
            return;
        }

        node.Init(showEvent, btn);
    }

    public void SetState(string key, string subKey, RedPointState state, int data = 0)
    {
        RedPoint root = GetRoot(key);

        if (root == null)
        {
            Debug.LogError("The red point root [" + key + "] is invalid,please add it first");
            return;
        }

        root.SetState(subKey, state, data);
    }


    private RedPoint GetRoot(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            return null;
        }

        for (int i = 0; i < m_ListRedPointTrees.Count; i++)
        {
            if (m_ListRedPointTrees[i].key.Equals(key))
            {
                return m_ListRedPointTrees[i];
            }
        }

        return null;
    }

    public void Dispose()
    {
        for (int i = m_ListRedPointTrees.Count - 1; i >= 0; i--)
        {
            m_ListRedPointTrees[i].Dispose();
        }

        m_ListRedPointTrees.Clear(); ;
    }

    private static RedPointMgr s_Instance = null;
    private List<RedPoint> m_ListRedPointTrees = null;
}