using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _lookDirectionAngle = 7f;

    private bool _attackIsOnCooldown = false;
    private float _attackRate;

    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _attackRate = _enemy.AttackRate;
    }

    private void FixedUpdate()
    {
        Rotate(_enemy.TargetsTranform);
        TryShoot();
    }

    public void Rotate(Transform targetTransform)
    {
        Vector3 direction = targetTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    private void TryShoot()
    {
        if(_attackIsOnCooldown == false)
        {
            Debug.Log("Enemy is shooting");
            StartCoroutine(CountAttackCooldown(_attackRate));
        }
    }

    private IEnumerator CountAttackCooldown(float attackRate)
    {
        float elapsedTime = 0;
        _attackIsOnCooldown = true;

        while(elapsedTime <= attackRate)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _attackIsOnCooldown = false;
    }
}
