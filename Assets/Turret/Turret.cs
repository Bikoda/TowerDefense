using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] int goldPayenemt = 75;
    Bank bank;
    // Start is called before the first frame update
    void Start()
    {
        bank = FindAnyObjectByType<Bank>();
    }
    public void GoldPayment()
    {
        if (bank == null) { return; }
        bank.Withdraw(goldPayenemt);
    }
}
