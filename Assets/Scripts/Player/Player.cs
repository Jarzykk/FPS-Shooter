using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private PlayersInventory _inventory;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private ImportantSceneObjects _importantSceneObjects;

    private bool _isAlive => _health.CurrentHealth > 0;

    public bool IsAlive => _isAlive;
    public int CurrentWeaponAmmoAmount => _inventory.CurrentMagazineBulletsAmount;
    public Health Health => _health;

    public event UnityAction WeaponChanged;
    public event UnityAction AmmoAmountChanged;
    public event UnityAction Died;

    private void OnEnable()
    {
        _health.Died += OnDeath;
        _inventory.WeaponSwitched += OnWeaponChanged;
        _inventory.AmmoAmountChanged += OnAmmoAmountChanged;
        _importantSceneObjects.LevelConditions.LevelEnded += DisableInput;
    }

    private void OnDisable()
    {
        _inventory.WeaponSwitched -= OnWeaponChanged;
        _inventory.AmmoAmountChanged -= OnAmmoAmountChanged;
        _health.Died -= OnDeath;
        _importantSceneObjects.LevelConditions.LevelEnded -= DisableInput;
    }

    private void OnDeath()
    {
        DisableInput();
        Died?.Invoke();
    }

    private void DisableInput()
    {
        _inputManager.DisableControlls();
    }

    private void OnWeaponChanged()
    {
        WeaponChanged?.Invoke();
    }

    private void OnAmmoAmountChanged()
    {
        AmmoAmountChanged?.Invoke();
    }
}
