using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Camera _shootCamera;

    private float _timeSinceLastShot = 0;
    private bool _canShoot => _timeSinceLastShot > 1f / (gunData.FireRate / 60f);

    private void OnEnable()
    {
        _inputManager.ShootButtonPressed += Shoot;
    }

    private void OnDisable()
    {
        _inputManager.ShootButtonPressed -= Shoot;
    }

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;
    }

    public void Shoot()
    {
        if(_canShoot)
        {
            if(Physics.Raycast(_shootCamera.transform.position, _shootCamera.transform.forward, out RaycastHit hitInfo, gunData.MaxDistance))
            {
                IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                damageable?.TakeDamage(gunData.Damage);
            }

            _timeSinceLastShot = 0;

            OnGunShot();
        }
    }

    private void OnGunShot()
    {

    }
}
