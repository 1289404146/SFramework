using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem
{
    private Dictionary<StateID, FSMState> states = new Dictionary<StateID, FSMState>();

    private StateID currentStateID;
    private FSMState currentFSMState;

    public void Update(GameObject npc)
    {
        currentFSMState.Act(npc);
        currentFSMState.Reason(npc);
    }

    /// <summary>
    /// Ìí¼Ó×´Ì¬
    /// </summary>
    /// <param name="fSMState"></param>
    public void AddState(FSMState fSMState)
    {
        if (fSMState == null) return;

        //if (currentFSMState == null)
        //{
        currentStateID = fSMState.ID;
        currentFSMState = fSMState;
        //}
        if (states.ContainsKey(currentStateID)) return;
        states.Add(currentStateID, currentFSMState);
    }
    /// <summary>
    /// É¾³ý×´Ì¬
    /// </summary>
    /// <param name="stateID"></param>
    public void DeleteState(StateID stateID)
    {
        if (stateID == StateID.Null) return;
        if (!states.ContainsKey(stateID)) return;

        states.Remove(stateID);
    }


    /// <summary>
    /// Ö´ÐÐ×´Ì¬Ìõ¼þ×ª»»
    /// </summary>
    /// <param name="transition"></param>
    public void PerformTransition(Transition transition)
    {
        if (transition == Transition.NullTransition) return;

        StateID stateID = currentFSMState.GetStateID(transition);
        if (stateID == StateID.Null) return;
        if (!states.ContainsKey(stateID)) return;

        FSMState fSMState = states[stateID];
        currentFSMState.StateExit();
        currentFSMState = fSMState;
        currentStateID = fSMState.ID;
        currentFSMState.StateEnter();
    }
}