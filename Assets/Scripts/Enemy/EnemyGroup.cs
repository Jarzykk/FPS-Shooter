using UnityEngine;
using UnityEngine.Events;

public class EnemyGroup : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private ImportantSceneObjects _inportantSceneObjects;


    private int _deadEnemiesCount = 0;

    public event UnityAction AllEnemiesDead;
    public Player Player => _inportantSceneObjects.Player;

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

