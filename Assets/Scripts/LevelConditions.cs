using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelConditions : MonoBehaviour
{
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    public event UnityAction PlayerWon;
    public event UnityAction PlayerLoose;
    public event UnityAction LevelEnded;

    private void OnEnable()
    {
        _importantSceneObjects.EnemyGroup.AllEnemiesDead += OnAllEnemiesKilled;
        _importantSceneObjects.Player.Died += OnPlayerDeath;
    }

    private void OnDisable()
    {
        _importantSceneObjects.EnemyGroup.AllEnemiesDead -= OnAllEnemiesKilled;
        _importantSceneObjects.Player.Died -= OnPlayerDeath;
    }

    private void OnAllEnemiesKilled()
    {
        Debug.Log("Player won");
        PlayerWon?.Invoke();
        LevelEnded?.Invoke();
    }

    private void OnPlayerDeath()
    {
        Debug.Log("Player loose");
        PlayerLoose?.Invoke();
        LevelEnded?.Invoke();
    }
}
