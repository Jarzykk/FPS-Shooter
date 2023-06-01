using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun", order = 51)]
public class GunData : ScriptableObject
{
    [Header("Shooting")]
    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _fireRate;
    [SerializeField] private Bullet _bulletType;
        
    public int Damage => _damage;
    public float MaxDistance => _maxDistance;
    public float FireRate => _fireRate;
    public Bullet BulletType => _bulletType;
}