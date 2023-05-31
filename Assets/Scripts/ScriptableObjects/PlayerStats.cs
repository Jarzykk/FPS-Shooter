using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characters", menuName = "Characters/Player", order = 51)]
public class PlayerStats : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _jumpHeight;

    [Header("Stats")]
    [SerializeField] private int _health;

    public float MoveSpeed => _moveSpeed;
    public float SprintSpeed => _sprintSpeed;
    public float JumpHeight => _jumpHeight;
    public int Health => _health;
}
