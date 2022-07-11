using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject clothe;
    private Vector3 spawnPoint;
    public static int _spawnCounter;
    public int _spawnLimit;

    public Canvas canva;

    public GameObject allClothes;

    // timer
    public float _timer;
    private float _timerEqual;
    void Start()
    {
        _timerEqual = _timer;
        spawnPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
        _spawnCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ClotheSpawner();
    }
    public void ClotheSpawner()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0 && _spawnCounter<_spawnLimit)
        {

            // Ingame sahnesindeki clothes objesinin altýnda instantiate edilmesini saðlamamýz lazým
            Instantiate(clothe, spawnPoint, Quaternion.identity);
            clothe.transform.parent = allClothes.transform;
            _timer = _timerEqual;
            _spawnCounter += 1;
        }
    }


}
