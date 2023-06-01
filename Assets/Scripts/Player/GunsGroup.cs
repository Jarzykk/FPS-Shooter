using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunsGroup : MonoBehaviour
{
    [SerializeField] private Gun[] _guns;

    public Gun[] Guns => _guns;

    public event UnityAction ShootPefrormed;

    private void OnEnable()
    {
        SubscribeToGunsEvents();
    }

    private void OnDisable()
    {
        UnsubscribeToGunsEvents();
    }

    private void SubscribeToGunsEvents()
    {
        foreach (var gun in _guns)
        {
            gun.ShootPerformed += OnShoot;
        }
    }

    private void UnsubscribeToGunsEvents()
    {
        foreach (var gun in _guns)
        {
            gun.ShootPerformed -= OnShoot;
        }
    }

    private void OnShoot()
    {
        ShootPefrormed?.Invoke();
    }
}
