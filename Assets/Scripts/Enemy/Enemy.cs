using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRate;
    [SerializeField] private Player _player;
    [SerializeField] private float _fieldOfView;
    [SerializeField] private float _sightDistance;
    [SerializeField] private Transform _eysPosition;
    [SerializeField] private PersueState _persueState;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private Health _health;
    [SerializeField] private Collider _collider;
    [SerializeField] private StateMachine _stateMachine;

    public float AttackDistance => _attackDistance;
    public Player Player => _player;
    public Transform TargetsTranform => _player.transform;
    public float AttackRate => _attackRate;
    public float FieldOfView => _fieldOfView;
    public float SightDistance => _sightDistance;
    public Transform EysPosition => _eysPosition;
    public int Damage => _damage;

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
        _collider.enabled = false;
        _stateMachine.DisableStateMachine();
        Died?.Invoke();
    }
}
