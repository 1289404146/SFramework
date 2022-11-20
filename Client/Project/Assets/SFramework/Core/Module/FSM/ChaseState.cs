using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 追逐状态
/// </summary>
public class ChaseState : FSMState
{
    /// <summary>
    /// 移动速度
    /// </summary>
    private float moveSpeed = 2f;
    /// <summary>
    /// 玩家
    /// </summary>
    private Transform player;
    public ChaseState(FSMSystem fSM, Transform player) : base(fSM)
    {
        stateID = StateID.Chase;
        this.player = player;
    }

    public override void Act(GameObject npc)
    {
        npc.transform.LookAt(player.position);
        npc.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
    }

    public override void Reason(GameObject npc)
    {
        //npc.GetComponent<Animator>().SetFloat("Speed", moveSpeed / 2);
        npc.GetComponent<Animator>().SetInteger("Anim", (int)Anim.Run);
        if (Vector3.Distance(player.position, npc.transform.position) >= 10)
        {
            fSM.PerformTransition(Transition.LostPlayer);
        }
        else if (Vector3.Distance(player.position, npc.transform.position) <= 0.3F)
        {
            fSM.PerformTransition(Transition.AttackPlayer);
        }
    }
}