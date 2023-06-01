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
        PlayerWon?.Invoke();
        LevelEnded?.Invoke();
    }

    private void OnPlayerDeath()
    {
        PlayerLoose?.Invoke();
        LevelEnded?.Invoke();
    }
}
