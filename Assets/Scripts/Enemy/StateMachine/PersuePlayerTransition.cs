using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class PersuePlayerTransition : Transition
{
    [SerializeField] private TargetSightChecker _sightChecker;
    [SerializeField] private float _LostTargetDelayTransin = 3f;

    private Player _player;
    private Enemy _enemy;
    private bool _wasAbleToAimInLastFrame;

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

        if(_sightChecker.CanAimAtPlayer == false)
        {
            if (_wasAbleToAimInLastFrame == true)
            {
                _wasAbleToAimInLastFrame = false;
                StartCoroutine(TransitAfterDelay());
            }
        }

        if (_wasAbleToAimInLastFrame == false && _sightChecker.CanAimAtPlayer == true)
        {
            _wasAbleToAimInLastFrame = true;
            StopAllCoroutines();
        }
    }

    private IEnumerator TransitAfterDelay()
    {
        float elapsedTime = 0;

        while(elapsedTime <= _LostTargetDelayTransin && _wasAbleToAimInLastFrame == false && 
            _sightChecker.CanAimAtPlayer == false)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        if (_wasAbleToAimInLastFrame == false && _sightChecker.CanAimAtPlayer == false && _player.IsAlive)
            NeedTransit = true;
    }
}
