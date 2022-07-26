using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{

    [SerializeField] Button playButton;
    [SerializeField] Button upgradeWasherButton;
    [SerializeField] Button upgradeRopeButton;


    public void LoadMainScene()
    {
        SceneManager.LoadScene("InGame");
    }

  


    public void upgradeWasherTime()
    {
        if(Money.getMoney() > 300)
        {
            DragAndDrop.washerTime = DragAndDrop.washerTime - 1f;
            Money.spentMoney(300);
            SaveGame();
        }
     
    }

    public void upgradeRopeTime()
    {
        if (Money.getMoney() > 300)
        {
            DragAndDrop.ropeTime = DragAndDrop.ropeTime - 1f;
            Money.spentMoney(300);
            SaveGame();
        }

    }
    private void Start()
    {
        LoadGame();
    }

    public static void SaveGame()
    {
        PlayerPrefs.SetFloat("washerTime", DragAndDrop.washerTime);
        PlayerPrefs.SetFloat("ropeTime", DragAndDrop.ropeTime);
        PlayerPrefs.SetInt("money", Money.getMoney());
        PlayerPrefs.Save();
    }

    public static void LoadGame()
    {
        if (!PlayerPrefs.HasKey("money"))
        {
            Money.setMoney(0);
        } else Money.setMoney(PlayerPrefs.GetInt("money")); 

        if (PlayerPrefs.HasKey("washerTime") && PlayerPrefs.HasKey("ropeTime"))
        {
            DragAndDrop.washerTime = PlayerPrefs.GetFloat("washerTime");
            DragAndDrop.ropeTime = PlayerPrefs.GetFloat("ropeTime");
        }else if (PlayerPrefs.HasKey("washerTime"))
        {
            DragAndDrop.washerTime = PlayerPrefs.GetFloat("washerTime");
            DragAndDrop.ropeTime = 10f;
        }else if (PlayerPrefs.HasKey("ropeTime"))
        {
            DragAndDrop.washerTime = 10f;
            DragAndDrop.ropeTime = PlayerPrefs.GetFloat("ropeTime");
        }else{
            DragAndDrop.washerTime = 10f;
            DragAndDrop.ropeTime = 10f;
        }
    }

}
