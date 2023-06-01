using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;
    private bool _isDead = false;

    public int CurrentHealth => _currentHealth;

    public event UnityAction Died;
    public event UnityAction HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead == false)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke();

            if (_currentHealth <= 0)
            {
                _isDead = true;
                Died?.Invoke();
            }
        }
    }
}
