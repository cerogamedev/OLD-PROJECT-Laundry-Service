using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class StartScene : MonoBehaviour
{
    [SerializeField] Button StartButton;
    [SerializeField] GameObject ShopButton;
    [SerializeField] Button soundControllerButton;
    public AudioSource audioS;

    

    void Start()
    {
        audioS = gameObject.GetComponent<AudioSource>();
        ShopSystem.LoadGame();
    }

    public void BGMusicController()
    {
        audioS.mute = !audioS.mute;
    }

    public void StartLoadScene()
    {
        SceneManager.LoadScene("InGame");
    }

    public void ShopLoadScene()
    {
        SceneManager.LoadScene("Shop");

    }

    public void musicOnOff()
    {

    }
}
