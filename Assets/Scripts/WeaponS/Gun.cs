using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    [SerializeField] private GunData _gunData;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private Camera _shootCamera;
    [SerializeField] private PlayersInventory _playerInventory;
    [SerializeField] private ParticleSystem _shootEffect;

    private float _timeSinceLastShot = 0;
    private bool _canShoot => _timeSinceLastShot > 1f / (_gunData.FireRate / 60f);

    public Bullet BulletType => _gunData.BulletType;

    public event UnityAction ShootPerformed;

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
        int bulletsAmount = _playerInventory.GetBulletsAmount(_gunData.BulletType);

        if (_canShoot && bulletsAmount > 0)
        {
            if (Physics.Raycast(_shootCamera.transform.position, _shootCamera.transform.forward, out RaycastHit hitInfo, _gunData.MaxDistance))
            {
                IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                damageable?.TakeDamage(_gunData.Damage);
            }

            _shootEffect.Play();
            _timeSinceLastShot = 0;
            OnGunShot();
        }
    }

    private void OnGunShot()
    {
        _playerInventory.RemoveBullet(_gunData.BulletType);
        ShootPerformed?.Invoke();
    }
}
