using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;

    private bool _isAlive => _health.CurrentHealth > 0;

    public bool IsAlive => _isAlive;
}
