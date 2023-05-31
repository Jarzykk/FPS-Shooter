using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Camera _shootingCamera;

    public void Shoot()
    {
        RaycastHit hit; 
        Physics.Raycast(_shootingCamera.transform.position, _shootingCamera.transform.forward, out hit);

        if(hit.transform.gameObject.TryGetComponent<IDamageable>(out IDamageable target))
        {
            Debug.Log(target);
        }
    }
}
