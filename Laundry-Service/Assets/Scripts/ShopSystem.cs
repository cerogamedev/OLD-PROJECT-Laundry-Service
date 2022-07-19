using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopSystem : MonoBehaviour
{

    [SerializeField] Button playButton;
     

    public void LoadMainScene()
    {
        SceneManager.LoadScene("InGame");
    } 
}
