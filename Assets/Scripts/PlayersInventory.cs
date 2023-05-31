using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersInventory : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;

    private Bullet[] _bullets;
    private BulletMagazine[] _bulletMagazines;

    public Gun[] Guns => _guns;
    public Bullet[] Bullets => _bullets;

    private void Start()
    {
        SetBullets();
        CreateMagazines();
    }

    private void SetBullets()
    {
        _bullets = new Bullet[_guns.Length];

        for (int i = 0; i < _bullets.Length; i++)
        {
            _bullets[i] = _guns[i].BulletType;
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

    public void RemoveBullet(Bullet bullet)
    {
        foreach (var magazine in _bulletMagazines)
        {
            if (magazine.BulletType == bullet)
            {
                magazine.RemoveBulletAmount(1);
                break;
            }
        }
    }
}
