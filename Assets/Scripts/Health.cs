using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private bool _isDead = false;

    public event UnityAction Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(_isDead == false)
        {
            _currentHealth -= damage;
            Debug.Log("Took damage");

            if (_currentHealth <= 0)
            {
                _isDead = true;
                Died?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}