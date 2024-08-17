using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    TextMeshPro textMeshPro;
    private int startingBalance = 151;
    private int currentBalance;
    [SerializeField] GameObject gold;
    private int pachinko = 0;
    public int CurrentBalance { get { return currentBalance; } }
    void Awake()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        

        currentBalance = startingBalance;
    }
 

    void Update()
    {
        TMP_Text goldText = gold.GetComponent<TMP_Text>();

        if (goldText != null)
        {
            // Update the text
            goldText.text = $"Gold: {currentBalance}";
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"You have {currentBalance} coins");
        }
        if (currentBalance < pachinko)
        {
            
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

        if (currentBalance < pachinko) 
        {
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("You've lost");
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
}
