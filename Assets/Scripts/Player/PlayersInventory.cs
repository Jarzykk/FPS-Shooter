using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInventory : MonoBehaviour
{
    [SerializeField] private GunsGroup _gunsGroup;
    [SerializeField] private WeaponSwitching _weaponSwitching;

    private Bullet[] _bullets;
    private BulletMagazine[] _bulletMagazines;

    public Gun[] Guns => _gunsGroup.Guns;
    public Bullet[] Bullets => _bullets;

    private Gun _currentGun;

    private void OnEnable()
    {
        _weaponSwitching.WeapoSwitched += OnWeaponSwitched;
    }

    private void OnDisable()
    {
        _weaponSwitching.WeapoSwitched -= OnWeaponSwitched;
        _currentGun.ShootPerformed -= OnGunShoot;
    }

    private void Start()
    {
        SetBullets();
        CreateMagazines();
    }

    private void SetBullets()
    {
        _bullets = new Bullet[_gunsGroup.Guns.Length];

        for (int i = 0; i < _bullets.Length; i++)
        {
            _bullets[i] = _gunsGroup.Guns[i].BulletType;
        }
    }

    private void CreateMagazines()
    {
        int minBulletAmount = 10;
        int maxBulletAmount = 15;

        _bulletMagazines = new BulletMagazine[_bullets.Length];

        for (int i = 0; i < _bulletMagazines.Length; i++)
        {
            int bulletsAmount = Random.Range(minBulletAmount, maxBulletAmount);
            _bulletMagazines[i] = new BulletMagazine(_bullets[i], bulletsAmount);
        }
    }

    public int GetBulletsAmount(Bullet bullet)
    {
        int bulletAmount = 0;

        foreach (var magazine in _bulletMagazines)
        {
            if(magazine.BulletType == bullet)
            {
                bulletAmount = magazine.BulletAmount;
                break;
            }
        }

        return bulletAmount;
    }

    private void OnWeaponSwitched(Gun gun)
    {
        if(_currentGun != null)
            _currentGun.ShootPerformed -= OnGunShoot;

        _currentGun = gun;
        _currentGun.ShootPerformed += OnGunShoot;
    }

    private void OnGunShoot()
    {
        RemoveBullet(_currentGun.BulletType);
    }

    public void RemoveBullet(Bullet bullet)
    {
        int amountToRemove = 1;

        foreach (var magazine in _bulletMagazines)
        {
            if (magazine.BulletType == bullet)
            {
                magazine.RemoveBulletAmount(amountToRemove);
                break;
            }
        }
    }
}
