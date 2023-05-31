using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun", order = 51)]
public class GunData : ScriptableObject
{

    [Header("Info")]
    [SerializeField] private new string name;

    [Header("Shooting")]
    [SerializeField] private int _damage;
    [SerializeField] private float _maxDistance;
    [SerializeField] private float _fireRate;
        

    public string Name => name;
    public int Damage => _damage;
    public float MaxDistance => _maxDistance;
    public float FireRate => _fireRate;
}