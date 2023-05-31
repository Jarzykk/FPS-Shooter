using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;

    private const string _shootTriggerName = "Shoot";
    private const string _runningBoolName = "IsRunning";

    private void OnEnable()
    {
        _enemy.Shoot += OnShoot;
        _enemy.StartedMovement += OnStartedMovement;
        _enemy.StoppedMovement += OnStoppedMovement;
    }

    private void OnDisable()
    {
        _enemy.Shoot -= OnShoot;
        _enemy.StartedMovement -= OnStartedMovement;
        _enemy.StoppedMovement -= OnStoppedMovement;
    }

    private void OnShoot()
    {
        _animator.SetTrigger(_shootTriggerName);
    }

    private void OnStartedMovement()
    {
        _animator.SetBool(_runningBoolName, true);
    }

    private void OnStoppedMovement()
    {
        _animator.SetBool(_runningBoolName, false);
    }
}
