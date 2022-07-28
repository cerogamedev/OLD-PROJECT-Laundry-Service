using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{

    public TextMeshProUGUI moneyText;
    public static int currentMoney;
 
    void Update()
    {
        setMoneyText();
    }


    public static int getMoney()
    {
        return currentMoney;
    }

    public static void setMoney(int amount)
    {
        currentMoney = amount;
    }

    public static void earnMoney(int amount)
    {
        currentMoney = getMoney() + amount;
    }

    public static void spentMoney(int amount)
    {
        currentMoney = getMoney() - amount;
    }

     private void setMoneyText()
     {
        moneyText.text = getMoney() + "";
     }
  
}
