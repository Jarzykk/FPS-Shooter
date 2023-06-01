using UnityEngine;

public class EnemyEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shootEffect;
    [SerializeField] private AttackState _attackState;

    private void OnEnable()
    {
        _attackState.Shoot += OnShoot;
    }

    private void OnDisable()
    {
        _attackState.Shoot -= OnShoot;
    }

    private void OnShoot()
    {
        _shootEffect.Play();
    }
}
