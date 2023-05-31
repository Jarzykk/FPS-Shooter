using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    [SerializeField] private Animator _gunAnimator;
    [SerializeField] private Gun _gun;

    private const string _shootAnimTriggerName = "Shoot";

    private void OnEnable()
    {
        _gun.ShootPerformed += OnShoot; 
    }

    private void OnDisable()
    {
        _gun.ShootPerformed -= OnShoot;
    }

    private void OnShoot()
    {
        _gunAnimator.SetTrigger(_shootAnimTriggerName);
    }
}
