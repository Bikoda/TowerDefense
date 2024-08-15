using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    
    [SerializeField] GameObject enemy;
    //private int[] wave = { 10,15,30 };
    [SerializeField] int poolSize = 5;
    private GameObject[] pool;
    void Awake()
    {
        PopulateObjectPool();
    }

    private void PopulateObjectPool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++) 
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        float time = Time.time;
        StartCoroutine(EnemySpawn());
    }




    IEnumerator EnemySpawn()
    {
        while (true)
        {
            Debug.Log("Enemy spawning now");
            EnableObjectsInPool();
            yield return new WaitForSecondsRealtime(1);
        }
    }

    private void EnableObjectsInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
            
        }
    }
}
