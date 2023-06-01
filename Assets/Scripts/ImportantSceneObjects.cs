using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantSceneObjects : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemyGroup _enemyGroup;

    public Player Player => _player;
    public EnemyGroup EnemyGroup => _enemyGroup;
}
