using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Animator _animator;

    private const string _shootTriggerName = "Shoot";
    private const string _runningBoolName = "IsRunning";
    private const string _deathTriggerName = "IsDead";

    private void OnEnable()
    {
        _enemy.EnemyConditions.Shoot += OnShoot;
        _enemy.EnemyConditions.StartedMovement += OnStartedMovement;
        _enemy.EnemyConditions.StoppedMovement += OnStoppedMovement;
        _enemy.EnemyConditions.Died += OnDeath;
    }

    private void OnDisable()
    {
        _enemy.EnemyConditions.Shoot -= OnShoot;
        _enemy.EnemyConditions.StartedMovement -= OnStartedMovement;
        _enemy.EnemyConditions.StoppedMovement -= OnStoppedMovement;
        _enemy.EnemyConditions.Died -= OnDeath;
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

    private void OnDeath()
    {
        _animator.SetTrigger(_deathTriggerName);
    }
}
