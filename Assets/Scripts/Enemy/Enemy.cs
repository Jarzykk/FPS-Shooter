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

    private void OnEnable()
    {
        _attackState.Shoot += OnShoot;
        _persueState.StartedMovement += OnStartedMovement;
        _persueState.StoppedMovement += OnStoppedMovement;
    }

    private void OnDisable()
    {
        _attackState.Shoot -= OnShoot;
        _persueState.StartedMovement -= OnStartedMovement;
        _persueState.StoppedMovement -= OnStoppedMovement;
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
}
