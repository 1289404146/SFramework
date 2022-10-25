using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Transition
{
    NullTransition,
    SeePlayer,//·¢ÏÖÍæ¼Ò
    LostPlayer,//Íæ¼ÒÍÑÀëÊÓÒ°·¶Î§
    AttackPlayer,//¹¥»÷Íæ¼Ò
}
public enum StateID
{
    Null,
    Chase,//×·Öð
    Patrol,//Ñ²Âß
    Attack,//¹¥»÷
}
public abstract class FSMState
{
    protected Transition transition;

    protected StateID stateID;
    protected FSMSystem fSM;
    public StateID ID
    {
        get { return stateID; }
    }

    protected Dictionary<Transition, StateID> dic = new Dictionary<Transition, StateID>();

    public FSMState(FSMSystem fSM)
    {
        this.fSM = fSM;
    }

    /// <summary>
    /// Ôö¼Ó×´Ì¬
    /// </summary>
    /// <param name="transition"></param>
    /// <param name="stateID"></param>
    public void AddTransition(Transition transition, StateID stateID)
    {
        if (transition == Transition.NullTransition) return;
        if (stateID == StateID.Null) return;
        if (dic.ContainsKey(transition)) return;

        dic.Add(transition, stateID);
    }
    /// <summary>
    /// É¾³ý×´Ì¬
    /// </summary>
    /// <param name="transition"></param>
    public void DeleteTransition(Transition transition)
    {
        if (transition == Transition.NullTransition) return;
        if (!dic.ContainsKey(transition)) return;

        dic.Remove(transition);
    }
    /// <summary>
    /// »ñÈ¡×´Ì¬
    /// </summary>
    /// <param name="transition"></param>
    /// <returns></returns>
    public StateID GetStateID(Transition transition)
    {
        if (transition == Transition.NullTransition) return StateID.Null;
        if (!dic.ContainsKey(transition)) return StateID.Null;
        return dic[transition];
    }

    /// <summary>
    /// ½øÈë×´Ì¬
    /// </summary>
    public virtual void StateEnter() { }
    /// <summary>
    /// ÍË³ö×´Ì¬
    /// </summary>
    public virtual void StateExit() { }

    /// <summary>
    /// ×´Ì¬³ÖÐøÖÐ£¬£¬£¬
    /// </summary>
    /// <param name="npc"></param>
    public abstract void Act(GameObject npc);
    /// <summary>
    /// ×´Ì¬ÍË³öÇ°£¬£¬£¬
    /// </summary>
    /// <param name="npc"></param>
    public abstract void Reason(GameObject npc);
}