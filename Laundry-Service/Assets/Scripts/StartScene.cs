using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class StartScene : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] GameObject ShopButton;

    void Start()
    {
        
    }
    void Update()
    {

    }

    public void StartLoadScene()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void ShopLoadScene()
    {
        SceneManager.LoadScene("Shop");

    }
}
