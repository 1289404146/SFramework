using System;
using System.Collections.Generic;
using UnityEngine.UI;

public enum RedPointType
{
    None,
    Enternal,//一直存在
    Once,//点击一次就消失
}

public enum RedPointState
{
    None,
    Show,
    Hide,
}

public class RedPoint
{
    /// <summary>
    /// 主关键字(属于哪一个根节点)
    /// </summary>
    public string key
    {
        get
        {
            return m_Key;
        }
    }

    /// <summary>
    /// 自己的关键字
    /// </summary>
    public string subKey
    {
        get
        {
            return m_SubKey;
        }
    }

    /// <summary>
    /// 是否是根节点
    /// </summary>
    public bool isRoot
    {
        get
        {
            return m_IsRoot;
        }
    }

    /// <summary>
    /// 红点类型
    /// </summary>
    public RedPointType type
    {
        get
        {
            return m_Type;
        }
    }

    /// <summary>
    /// 当前状态
    /// </summary>
    public RedPointState state
    {
        get
        {
            return m_State;
        }
    }

    /// <summary>
    /// 数据
    /// </summary>
    public int data
    {
        get
        {
            return m_Data;
        }
    }

    /// <summary>
    /// 父节点
    /// </summary>
    public RedPoint parent
    {
        get
        {
            return m_Parent;
        }
    }

    /// <summary>
    /// 子节点
    /// </summary>
    public List<RedPoint> children
    {
        get
        {
            return m_Children;
        }
    }


    public RedPoint(string key, string subKey, bool isRoot, RedPointType type)
    {
        m_Key = key;
        m_SubKey = subKey;
        m_IsRoot = isRoot;
        m_Type = type;
        m_State = RedPointState.Hide;
        m_Data = 0;
        m_Children = new List<RedPoint>();
    }

    public void Init(Action<RedPointState, int> showEvent, Button btn)
    {
        m_ShowEvent = showEvent;

        if (btn != null)
        {
            m_Btn = btn;
            m_Btn.onClick.AddListener(OnClick);
        }

        m_ShowEvent?.Invoke(m_State, m_Data);
    }

    public void AddChild(RedPoint node, string parentKey)
    {
        if (m_SubKey.Equals(parentKey))
        {
            node.SetParent(this);
            m_Children.Add(node);
            return;
        }

        for (int i = 0; i < m_Children.Count; i++)
        {
            m_Children[i].AddChild(node, parentKey);
        }
    }

    public RedPoint GetChild(string subKey)
    {
        if (m_SubKey.Equals(subKey))
        {
            return this;
        }

        if (m_Children == null)
        {
            return null;
        }

        for (int i = 0; i < m_Children.Count; i++)
        {
            RedPoint node = m_Children[i].GetChild(subKey);

            if (node != null)
            {
                return node;
            }
        }

        return null;
    }

    public void RemoveChild(string subKey)
    {
        if (m_SubKey.Equals(subKey))
        {
            m_Parent.children.Remove(this);
            Dispose();
            return;
        }

        if (m_Children == null)
        {
            return;
        }

        for (int i = 0; i < m_Children.Count; i++)
        {
            m_Children[i].RemoveChild(subKey);
        }
    }

    public void SetParent(RedPoint parent)
    {
        m_Parent = parent;
    }

    public void SetState(string subKey, RedPointState state, int data)
    {
        RedPoint node = GetChild(subKey);

        if (node == null)
        {
            return;
        }

        node.SetTreeState(subKey, state, data);

        m_Data = 0;

        for (int i = 0; i < m_Children.Count; i++)
        {
            m_Data += m_Children[i].m_Data;
        }

        m_ShowEvent?.Invoke(m_State, m_Data);
    }

    private void SetTreeState(string subKey, RedPointState state, int data)
    {
        m_State = state;

        if (m_SubKey.Equals(subKey))
        {
            m_Data = data;
        }
        else
        {
            m_Data = 0;

            for (int i = 0; i < m_Children.Count; i++)
            {
                if (m_Children[i].state == RedPointState.Show)
                {
                    m_State = RedPointState.Show;
                    m_Data += m_Children[i].data;
                }
            }
        }

        if (m_Parent != null)
        {
            m_Parent.SetTreeState(subKey, state, data);
        }

        m_ShowEvent?.Invoke(m_State, m_Data);
    }

    private void OnClick()
    {
        if (m_Type == RedPointType.Once)
        {
            HideChildren();
            SetState(m_SubKey, RedPointState.Hide, m_Data);
        }
    }

    private void HideChildren()
    {
        m_State = RedPointState.Hide;

        for (int i = 0; i < m_Children.Count; i++)
        {
            m_Children[i].HideChildren();
        }

        m_ShowEvent?.Invoke(m_State, m_Data);
    }

    public void Dispose()
    {
        for (int i = 0; i < m_Children.Count; i++)
        {
            m_Children[i].Dispose();
        }

        m_Children.Clear();
        m_Children = null;

        if (m_Btn != null)
        {
            m_Btn.onClick.RemoveListener(OnClick);
        }

        m_Btn = null;
        m_Parent = null;
        m_Key = null;
        m_SubKey = null;
        m_ShowEvent = null;
        m_Type = RedPointType.None;
        m_State = RedPointState.None;
    }

    private string m_Key = string.Empty;
    private string m_SubKey = string.Empty;
    private bool m_IsRoot = false;
    private int m_Data = 0;
    private RedPointType m_Type = RedPointType.None;
    private RedPointState m_State = RedPointState.None;
    private Action<RedPointState, int> m_ShowEvent = null;
    private Button m_Btn;
    private RedPoint m_Parent = null;
    private List<RedPoint> m_Children = null;
}