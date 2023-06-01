using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private InputManager _inputManager;

    private bool _isAlive => _health.CurrentHealth > 0;

    public bool IsAlive => _isAlive;

    public event UnityAction Died;

    private void OnEnable()
    {
        _health.Died += OnDeath; 
    }

    private void OnDisable()
    {
        _health.Died -= OnDeath;
    }

    private void OnDeath()
    {
        _inputManager.DisableControlls();
        Died?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
