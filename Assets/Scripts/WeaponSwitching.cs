using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;
    [SerializeField] private float switchTime;
    [SerializeField] private InputManager _inputManager;

    private Gun _selectedWeapon;
    private float _timeSinceLastSwitch;

    private int _currentWeaponIndex;

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
        _currentWeaponIndex = 0;
        ChangeWeapon(_currentWeaponIndex);
    }

    private void ChangeWeapon(int index)
    {
        _currentWeaponIndex = index;

        _selectedWeapon = _guns[_currentWeaponIndex];
        _selectedWeapon.gameObject.SetActive(true);

        DisableNotSelectedWeapons();
    }

    private void DisableNotSelectedWeapons()
    {
        foreach (var gun in _guns)
        {
            if (gun != _selectedWeapon)
            {
                gun.gameObject.SetActive(false);
            }
        }
    }

    private void EquipNextWeapon()
    {
        if (_currentWeaponIndex == _guns.Length - 1)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

        ChangeWeapon(_currentWeaponIndex);
        Debug.Log("Next");
    }

    private void EquipPreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _guns.Length - 1;
        else
            _currentWeaponIndex--;

        ChangeWeapon(_currentWeaponIndex);
        Debug.Log("Previous");
    }
}