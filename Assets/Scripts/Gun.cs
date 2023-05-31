using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData gunData;
    [SerializeField] private InputManager _inputManager;

    private float _timeSinceLastShot = 0;
    private bool _canShoot => _timeSinceLastShot > 1f / (gunData.fireRate / 60f);

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
        if(gunData.currentAmmo > 0 && _canShoot)
        {
            if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
            {
                IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                damageable?.TakeDamage(gunData.damage);
            }

            gunData.currentAmmo--;
            _timeSinceLastShot = 0;

            OnGunShot();
        }
    }

    private void OnGunShot()
    {

    }
}
