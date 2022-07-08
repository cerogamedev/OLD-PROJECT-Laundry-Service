using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{

   [SerializeField] TextMeshProUGUI moneyText;
    public static int currentMoney;
   
    void Start()
    {
        temp();
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

    public void earnMoney(int amount)
    {
        currentMoney = getMoney() + amount;
    }

    public void spentMoney(int amount)
    {
        currentMoney = getMoney() - amount;
    }

     public void setMoneyText()
    {
       moneyText.text = getMoney() + "coins";
    }
  
}
