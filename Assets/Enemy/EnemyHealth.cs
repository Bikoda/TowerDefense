using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int enemyMaxHealth = 5;
    [Tooltip("adds ammount of hitpoints when enemy dies")]
    [SerializeField] int gameDificultyRamp = 1;
    int enemyCurrentHealth = 0;
    private bool enemySlain = false;
    Enemy enemy;
    void OnEnable()
    {
        enemy = FindAnyObjectByType<Enemy>();
        enemyCurrentHealth = enemyMaxHealth;
    }
    void Update()
    {
        DisablingEnemyOnHp();

        if (enemySlain)
        {
            EnemySlain(enemySlain);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        processHit();
        Debug.Log("you have hit something");
    }

    public bool EnemySlain(bool enemySlain)
    {
        return enemySlain = true;
    }

    void processHit()
    {
        enemyCurrentHealth--;
    }

    void DisablingEnemyOnHp()
    {
        if (enemyCurrentHealth < 1)
        {
            Debug.Log("You've Slain an enemy");
            gameObject.SetActive(false);
            enemySlain = true;
            enemy.GoldReward();
            enemyMaxHealth += gameDificultyRamp;
        }
    }
}

