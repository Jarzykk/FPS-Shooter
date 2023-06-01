using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class TargetSightChecker : MonoBehaviour
{
    private Enemy _enemy;
    private bool _canAimAtPlayer;

    public bool CanAimAtPlayer => _canAimAtPlayer;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        _canAimAtPlayer = CheckIfAimingToPlayer();
    }

    private bool CheckIfAimingToPlayer()
    {
        Vector3 targetDirection = _enemy.TargetsTranform.position - _enemy.EysPosition.position;
        float angleToPlayer = Vector3.Angle(transform.forward, targetDirection);

        if (angleToPlayer >= -_enemy.FieldOfView && angleToPlayer <= _enemy.FieldOfView)
        {
            Ray ray = new Ray(_enemy.EysPosition.position, targetDirection * _enemy.SightDistance);
            RaycastHit hitInfo = new RaycastHit();

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
}
