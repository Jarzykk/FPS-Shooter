using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyConditions : MonoBehaviour
{
    [SerializeField] private PersueState _persueState;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Health _health;

    public event UnityAction Shoot;
    public event UnityAction StartedMovement;
    public event UnityAction StoppedMovement;
    public event UnityAction Died;

    private void OnEnable()
    {
        _attackState.Shoot += OnShoot;
        _persueState.StartedMovement += OnStartedMovement;
        _persueState.StoppedMovement += OnStoppedMovement;
        _health.Died += OnDeath;
    }

    private void OnDisable()
    {
        _attackState.Shoot -= OnShoot;
        _persueState.StartedMovement -= OnStartedMovement;
        _persueState.StoppedMovement -= OnStoppedMovement;
        _health.Died -= OnDeath;
    }

    private void OnShoot()
    {
        Shoot?.Invoke();
    }

    private void OnStartedMovement()
    {
        StartedMovement?.Invoke();
    }

    private void OnStoppedMovement()
    {
        StoppedMovement?.Invoke();
    }

    private void OnDeath()
    {
        Died?.Invoke();
    }
}
