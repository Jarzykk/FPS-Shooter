using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackRate;
    [SerializeField] private Player _player;
    [SerializeField] private float _fieldOfView;
    [SerializeField] private float _sightDistance;
    [SerializeField] private Transform _eysPosition;

    public float AttackDistance => _attackDistance;
    public Player Player => _player;
    public Transform TargetsTranform => _player.transform;
    public float AttackRate => _attackRate;
    public float FieldOfView => _fieldOfView;
    public float SightDistance => _sightDistance;
    public Transform EysPosition => _eysPosition;
    public int Damage => _damage;
}
