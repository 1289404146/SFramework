using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private FSMSystem fSM;
    private Transform player;
    private void Start()
    {
        fSM = new FSMSystem();
        FSMState patrolState = new PatrolState(fSM, player);
        patrolState.AddTransition(Transition.SeePlayer, StateID.Chase);
        patrolState.AddTransition(Transition.AttackPlayer, StateID.Attack);
        //patrolState.AddTransition(Transition.LostPlayer, StateID.Patrol);

        FSMState chaseState = new ChaseState(fSM, player);
        chaseState.AddTransition(Transition.LostPlayer, StateID.Patrol);
        chaseState.AddTransition(Transition.AttackPlayer, StateID.Attack);
        //chaseState.AddTransition(Transition.SeePlayer, StateID.Chase);

        FSMState attackState = new AttackState(fSM, player);
        attackState.AddTransition(Transition.SeePlayer, StateID.Chase);
        attackState.AddTransition(Transition.LostPlayer, StateID.Patrol);
        //attackState.AddTransition(Transition.AttackPlayer, StateID.Attack);

        fSM.AddState(patrolState);
        fSM.AddState(chaseState);
        fSM.AddState(attackState);
    }

    private void Update()
    {
        fSM.Update(gameObject);
    }
}