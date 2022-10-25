using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ׷��״̬
/// </summary>
public class ChaseState : FSMState
{
    /// <summary>
    /// �ƶ��ٶ�
    /// </summary>
    private float moveSpeed = 2f;
    /// <summary>
    /// ���
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
        npc.GetComponent<Animator>().SetFloat("Speed", moveSpeed / 2);
        if (Vector3.Distance(player.position, npc.transform.position) >= 10)
        {
            fSM.PerformTransition(Transition.LostPlayer);
        }
        else if (Vector3.Distance(player.position, npc.transform.position) <= 1f)
        {
            fSM.PerformTransition(Transition.AttackPlayer);
        }
    }
}