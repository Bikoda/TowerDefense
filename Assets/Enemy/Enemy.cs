using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldPayenemt = 50;
    [SerializeField] int goldPenalty = 250;
    EnemyHealth health;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
    }
    public void GoldReward()
    {
       if (bank == null) {  return; }
       bank.Deposit(goldPayenemt);
    }
        
    public void GoldStolen()
    {

        if (bank == null) { return; };
        bank.Deposit(goldPenalty);
    }

}
