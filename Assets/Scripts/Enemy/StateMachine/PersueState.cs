using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent), typeof(Enemy))]
public class PersueState : State
{
    private NavMeshAgent _navMeshAgent;
    private Player _player;

    public event UnityAction StartedMovement;
    public event UnityAction StoppedMovement;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Enemy>().Player;
    }

    private void OnEnable()
    {
        _navMeshAgent.isStopped = false;
        StartedMovement?.Invoke();
    }

    private void OnDisable()
    {
        if(_navMeshAgent.isActiveAndEnabled)
            _navMeshAgent.isStopped = true;

        StoppedMovement?.Invoke();
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
    }
}
