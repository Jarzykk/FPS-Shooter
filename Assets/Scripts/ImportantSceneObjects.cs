using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGroup _enemyGroup;
    [SerializeField] private LevelConditions _levelConditions;

    public Player Player => _player;
    public EnemyGroup EnemyGroup => _enemyGroup;
    public LevelConditions LevelConditions => _levelConditions;
}
