using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackPlayerTransition : Transition
{
    [SerializeField] private TargetSightChecker _sightChecker;

    private float _attackRange;
    private Enemy _enemy;

    private void Start()
    {
        _attackRange = GetComponent<Enemy>().AttackDistance;
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _enemy.TargetsTranform.position);

        if(distanceToPlayer <= _attackRange && _sightChecker.CanAimAtPlayer == true)
        {
            NeedTransit = true;
        }
    }
}
