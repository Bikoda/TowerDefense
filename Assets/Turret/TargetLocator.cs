using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    void Start()
    {
        
        target = GameObject.FindAnyObjectByType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon(); 
    }

    void AimWeapon()
    {
        if (target != null)
        {
            weapon.LookAt(target);
        }
    }
}
