using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
   private int goldPayment = 75;
    Bank bank;

    public void GoldPayment()
    {
        bank.Withdraw(goldPayment);
    }

    public bool CreateTower(Turret turret, Vector3 position)
    {
        bank = FindAnyObjectByType<Bank>();
        if (bank == null)
        {
            return false;
        }
        if (bank.CurrentBalance > goldPayment)
        {
            Instantiate(turret, position, Quaternion.identity);
            bank.Withdraw(goldPayment);
            return true;
        }
        return false;
    }
}
