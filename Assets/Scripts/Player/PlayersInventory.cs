using UnityEngine;
using UnityEngine.Events;

[DefaultExecutionOrder(0)]
public class PlayersInventory : MonoBehaviour
{
    [SerializeField] private GunsGroup _gunsGroup;
    [SerializeField] private WeaponSwitching _weaponSwitching;
    [SerializeField] private int _minBulletsAmount = 30;
    [SerializeField] private int _maxBulletsAmount = 120;

    private Bullet[] _bullets;
    private BulletMagazine[] _bulletMagazines;

    public Gun[] Guns => _gunsGroup.Guns;
    public int CurrentMagazineBulletsAmount => _currentBulletMagazine.BulletAmount;

    private Gun _currentGun;
    private BulletMagazine _currentBulletMagazine;

    public event UnityAction AmmoAmountChanged;
    public event UnityAction WeaponSwitched;

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
        _bulletMagazines = new BulletMagazine[_bullets.Length];

        for (int i = 0; i < _bulletMagazines.Length; i++)
        {
            int bulletsAmount = Random.Range(_minBulletsAmount, _maxBulletsAmount);
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

    private BulletMagazine GetBulletMagazine(Gun gun)
    {
        BulletMagazine bulletMagazine = null;

        foreach (var magazine in _bulletMagazines)
        {
            if (gun.BulletType == magazine.BulletType)
                bulletMagazine = magazine;
        }

        return bulletMagazine;
    }

    private void OnWeaponSwitched(Gun gun)
    {
        if(_currentGun != null)
            _currentGun.ShootPerformed -= OnGunShoot;

        _currentGun = gun;
        _currentGun.ShootPerformed += OnGunShoot;

        _currentBulletMagazine = GetBulletMagazine(_currentGun);

        WeaponSwitched?.Invoke();
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

        AmmoAmountChanged?.Invoke();
    }
}
