using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(1)]
public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] private PlayersInventory _playerInventory;
    [SerializeField] private float switchTime;
    [SerializeField] private InputManager _inputManager;

    private Gun _selectedWeapon;

    private int _currentWeaponIndex;
    public event UnityAction<Gun> WeapoSwitched;

    private void OnEnable()
    {
        _inputManager.EquipNextWeaponPressed += EquipNextWeapon;
        _inputManager.EquipPreviousWeaponPressed += EquipPreviousWeapon;
    }

    private void OnDisable()
    {
        _inputManager.EquipNextWeaponPressed -= EquipNextWeapon;
        _inputManager.EquipPreviousWeaponPressed -= EquipPreviousWeapon;
    }

    private void Start()
    {
        DisableAllWeapons();

        _currentWeaponIndex = 0;
        ChangeWeapon(_currentWeaponIndex);
    }

    private void ChangeWeapon(int index)
    {
        if (_selectedWeapon != null)
            _selectedWeapon.gameObject.SetActive(false);


        _currentWeaponIndex = index;

        _selectedWeapon = _playerInventory.Guns[_currentWeaponIndex];
        _selectedWeapon.gameObject.SetActive(true);
        WeapoSwitched?.Invoke(_selectedWeapon);
    }

    private void DisableAllWeapons()
    {
        foreach (var gun in _playerInventory.Guns)
        {
            gun.gameObject.SetActive(false);
        }
    }

    private void EquipNextWeapon()
    {
        if (_currentWeaponIndex == _playerInventory.Guns.Length - 1)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

        ChangeWeapon(_currentWeaponIndex);
    }

    private void EquipPreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _playerInventory.Guns.Length - 1;
        else
            _currentWeaponIndex--;

        ChangeWeapon(_currentWeaponIndex);
    }
}