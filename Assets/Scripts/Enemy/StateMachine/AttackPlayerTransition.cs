using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackPlayerTransition : Transition
{
    private float _attackRange;
    private Player _player;

    private void Awake()
    {
        _attackRange = GetComponent<Enemy>().AttackDistance;
        _player = GetComponent<Enemy>().Player;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if(distanceToPlayer <= _attackRange)
        {
            NeedTransit = true;
        }
    }
}
