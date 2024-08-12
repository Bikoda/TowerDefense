using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyMaxHealth = 5;
    [SerializeField] int enemyCurrentHealth = 0;
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }
    void Update()
    {

        Death();
    }

    void OnParticleCollision(GameObject other)
    {

        processHit();
        Debug.Log("you have hit something");
    }

 

    void processHit()
    {
        enemyCurrentHealth--;
    }

    void Death()
    {
        if (enemyCurrentHealth < 1)
        {
            Destroy(gameObject);
        }
    }
}

