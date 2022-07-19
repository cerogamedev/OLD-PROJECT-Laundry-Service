using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{

    public TextMeshProUGUI moneyText;
    public static int currentMoney;

    private void Start()
    {
        temp();
    }

    void Update()
    {
        setMoneyText();
    }

    public void temp(){
        currentMoney = 100;
    }
 

    public static int getMoney()
    {
        return currentMoney;
    }

    public void setMoney(int amount)
    {
        currentMoney = amount;
    }

    public static void earnMoney(int amount)
    {
        currentMoney = getMoney() + amount;
    }

    public void spentMoney(int amount)
    {
        currentMoney = getMoney() - amount;
    }

     private void setMoneyText()
     {
        moneyText.text = getMoney() + " coins";
     }
  
}
