using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¹¥»÷×´Ì¬
/// </summary>
public class AttackState : FSMState
{
    /// <summary>
    /// Íæ¼Ò
    /// </summary>
    private Transform player;
    public AttackState(FSMSystem fSM, Transform player) : base(fSM)
    {
        stateID = StateID.Attack;
        this.player = player;
    }
    public override void Act(GameObject npc)
    {

    }

    public override void Reason(GameObject npc)
    {
        if (Vector3.Distance(player.position, npc.transform.position) > 0.3f)
        {
            if (Vector3.Distance(player.position, npc.transform.position) >= 10)
            {
                fSM.PerformTransition(Transition.LostPlayer);
            }
            else if (Vector3.Distance(player.position, npc.transform.position) < 10)
            {
                fSM.PerformTransition(Transition.SeePlayer);
            }
            return;
        }
        //npc.GetComponent<Animator>().SetTrigger("Attack01");
        npc.GetComponent<Animator>().SetInteger("Anim",(int)Anim.Attack);

    }
}