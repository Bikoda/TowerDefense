using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    private int pachinko = -1;
    public int CurrentBalance { get { return currentBalance; } }
    void Awake()
    {
        
        currentBalance = startingBalance;    
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log($"You have {currentBalance} coins");
        }
        if (currentBalance < pachinko) 
        {
            GameOver();
        }

       
    }

    public void Deposit(int ammount)
    {
        currentBalance += Mathf.Abs(ammount);
        Debug.Log($"There has been a deposit of {ammount} coins to the bank");
    }

    public void Withdraw(int ammount) 
    {
        currentBalance -= Mathf.Abs(ammount);
        Debug.Log($"There has been a withdrawal of {ammount} coins from the bank");
    }
    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
