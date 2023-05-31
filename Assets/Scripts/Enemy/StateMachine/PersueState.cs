using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Enemy))]
public class PersueState : State
{
    private NavMeshAgent _navMeshAgent;
    private Player _player;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Enemy>().Player;
    }

    private void OnEnable()
    {
        _navMeshAgent.isStopped = false;
    }

    private void OnDisable()
    {
        _navMeshAgent.isStopped = true;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
    }
}
