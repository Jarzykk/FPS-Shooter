using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private TargetSightChecker _targetSightChecker;
    [SerializeField] private float _rotationSpeed = 7f;
    [SerializeField, Range(0, 100)] private int _accuracyOffset = 3;

    private bool _attackIsOnCooldown = false;
    private float _attackRate => _enemy.AttackRate;
    private bool _aimAtPlayer;

    private Enemy _enemy;

    public event UnityAction Shoot;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        _aimAtPlayer = _targetSightChecker.CanAimAtPlayer;
        Rotate(_enemy.TargetsTranform);

        if(_aimAtPlayer)
            TryShoot();
    }

    private void Rotate(Transform targetTransform)
    {
        Vector3 direction = targetTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    private void TryShoot()
    {
        if(_attackIsOnCooldown == false)
        {
            Vector3 targetDirection = _enemy.TargetsTranform.position - _enemy.EysPosition.position;
            int accuracyOffset = Random.Range(0, _accuracyOffset);
            Vector3 vectorAccuracyOffset = new Vector3(accuracyOffset, accuracyOffset, accuracyOffset);
            targetDirection += vectorAccuracyOffset;

            Ray ray = new Ray(_enemy.EysPosition.position, targetDirection * _enemy.SightDistance);
            RaycastHit hitInfo = new RaycastHit();
            Debug.DrawRay(_enemy.EysPosition.position, targetDirection * _enemy.SightDistance);

            if (Physics.Raycast(ray, out hitInfo, _enemy.SightDistance))
            {
                if (hitInfo.transform.TryGetComponent<IDamageable>(out IDamageable iDamageable))
                {
                    iDamageable.TakeDamage(_enemy.Damage);
                }
            }

            Shoot?.Invoke();
            StartCoroutine(CountAttackCooldown(_attackRate));
        }
    }

    private IEnumerator CountAttackCooldown(float attackRate)
    {
        float elapsedTime = 0;
        _attackIsOnCooldown = true;

        while (elapsedTime <= attackRate)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _attackIsOnCooldown = false;
    }
}
