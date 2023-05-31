using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class PersuePlayerTransition : Transition
{
    private Player _player;
    private Enemy _enemy;

    private void Awake()
    {
        _player = GetComponent<Enemy>().Player;
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (_player.IsAlive && distanceToPlayer > _enemy.AttackDistance)
            NeedTransit = true;
    }
}
