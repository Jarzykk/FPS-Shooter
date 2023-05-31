using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Enemy))]
public class AttackState : State
{
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _lookDirectionAngle = 7f;
    [SerializeField, Range(0f, 100f)] private float _accuracy = 33f;

    private bool _attackIsOnCooldown = false;
    private float _attackRate;
    private bool _aimAtPlayer;

    private Enemy _enemy;

    public event UnityAction Shoot;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _attackRate = _enemy.AttackRate;
    }

    private void FixedUpdate()
    {
        _aimAtPlayer = CkeckIfAimingToPlayer();
        Rotate(_enemy.TargetsTranform);

        if(_aimAtPlayer)
            TryShoot();

        Debug.Log(_aimAtPlayer);
    }

    private void Rotate(Transform targetTransform)
    {
        Vector3 direction = targetTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    private bool CkeckIfAimingToPlayer()
    {
        Vector3 targetDirection = _enemy.Player.transform.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, targetDirection);

        if (angleToPlayer >= -_enemy.FieldOfView && angleToPlayer <= _enemy.FieldOfView)
        {
            Debug.Log("InAngle");
            Ray ray = new Ray(_enemy.EysPosition.position, transform.forward * _enemy.SightDistance);
            RaycastHit hitInfo = new RaycastHit();
            Debug.DrawRay(_enemy.EysPosition.position, transform.forward * _enemy.SightDistance);

            if (Physics.Raycast(ray, out hitInfo, _enemy.SightDistance))
            {
                if (hitInfo.transform.GetComponent<Player>())
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void TryShoot()
    {
        if(_attackIsOnCooldown == false)
        {
            float shootAccuracy = Random.Range(0, 100);
            if(shootAccuracy <= _accuracy)
            {
                _enemy.Player.TakeDamage(_enemy.Damage);
                Shoot?.Invoke();
            }
            else
            {
                Debug.Log("Missed");
            }
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
