using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerHealth;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private void OnEnable()
    {
        _importantSceneObjects.Player.Health.HealthChanged += UpdateHealthAmount;
    }

    private void OnDisable()
    {
        _importantSceneObjects.Player.Health.HealthChanged -= UpdateHealthAmount;
    }

    private void UpdateHealthAmount()
    {
        _playerHealth.text = _importantSceneObjects.Player.Health.CurrentHealth.ToString();
    }
}
