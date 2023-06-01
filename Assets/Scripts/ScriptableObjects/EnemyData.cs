using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies/EnemyBasic", order = 52)]
public class EnemyData : ScriptableObject
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRate;

    public float AttackDistance => _attackDistance;
    public int Damage => _damage;
    public float AttackRate => _attackRate;
}
