using UnityEngine;

public class BulletMagazine : MonoBehaviour
{
    private Bullet _bulletType;
    private int _bulletAmount;

    public Bullet BulletType => _bulletType;
    public int BulletAmount => _bulletAmount;

    public BulletMagazine(Bullet bulletType, int bulletAmount)
    {
        _bulletType = bulletType;
        _bulletAmount = bulletAmount;
    }

    public void RemoveBulletAmount(int amount)
    {
        if (_bulletAmount - amount >= 0)
            _bulletAmount -= amount;
        else
            _bulletAmount = 0;
    }
}
