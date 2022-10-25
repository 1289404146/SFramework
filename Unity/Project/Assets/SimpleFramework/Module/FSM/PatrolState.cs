using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ѳ��״̬
/// </summary>
public class PatrolState : FSMState
{
    /// <summary>
    /// Ѳ��·���㼯��
    /// </summary>
    private Transform[] paths;
    /// <summary>
    /// ��ǰѲ��·��������
    /// </summary>
    private int index = 0;
    /// <summary>
    /// �ƶ��ٶ�
    /// </summary>
    private float moveSpeed = 0.5f;
    /// <summary>
    /// ���
    /// </summary>
    private Transform player;
    public PatrolState(FSMSystem fSM, Transform player) : base(fSM)
    {
        this.player = player;
        paths = GameObject.Find("Path").GetComponentsInChildren<Transform>();
        stateID = StateID.Patrol;
    }

    public override void Act(GameObject npc)
    {
        npc.transform.LookAt(paths[index].position);
        npc.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        if (Vector3.Distance(npc.transform.position, paths[index].position) < 1)
        {
            index++;
            index %= paths.Length;
        }
    }

    public override void Reason(GameObject npc)
    {
        npc.GetComponent<Animator>().SetFloat("Speed", moveSpeed);
        if (Vector3.Distance(player.position, npc.transform.position) < 10)
        {
            fSM.PerformTransition(Transition.SeePlayer);
        }
    }
}