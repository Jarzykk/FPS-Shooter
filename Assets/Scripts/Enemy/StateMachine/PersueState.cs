using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent), typeof(Enemy))]
public class PersueState : State
{
    private Enemy _enemy;
    private NavMeshAgent _navMeshAgent;

    public event UnityAction StartedMovement;
    public event UnityAction StoppedMovement;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
        _navMeshAgent.SetDestination(_enemy.TargetsTranform.transform.position);
    }
}
