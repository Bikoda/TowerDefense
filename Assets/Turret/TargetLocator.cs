using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    private float towerRange = 25;
    [SerializeField] ParticleSystem projectileParticles;

    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float MaxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float TargetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (TargetDistance < MaxDistance)
            {
                closestTarget = enemy.transform;

                MaxDistance = TargetDistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        if (target != null)
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);
            if (targetDistance <= towerRange)
            {
                weapon.LookAt(target);
                Attack(true);
            }
            else
            {
                Attack(false);
                transform.rotation = Quaternion.identity;
            }
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emission = projectileParticles.emission;
        emission.enabled = isActive;
    }
}
