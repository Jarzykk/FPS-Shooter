using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;

    private int _deadEnemiesCount = 0;

    public event UnityAction AllEnemiesDead;

    private void OnEnable()
    {
        SubscibeToEnemiesDeathEvents();
    }

    private void OnDisable()
    {
        UnsubscribeFromEnemiesDeathEvents();
    }

    private void SubscibeToEnemiesDeathEvents() 
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died += OnEnemyDeath;
        }
    }

    private void UnsubscribeFromEnemiesDeathEvents() 
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnEnemyDeath;
        }
    }

    private void OnEnemyDeath()
    {
        _deadEnemiesCount++;

        if(_deadEnemiesCount >= _enemies.Length)
        {
            AllEnemiesDead?.Invoke();
        }
    }
}

