using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 巡逻状态
/// </summary>
public class PatrolState : FSMState
{
    /// <summary>
    /// 巡逻路径点集合
    /// </summary>
    private Transform[] paths;
    /// <summary>
    /// 当前巡逻路径点索引
    /// </summary>
    private int index = 0;
    /// <summary>
    /// 移动速度
    /// </summary>
    private float moveSpeed = 0.5f;
    /// <summary>
    /// 玩家
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