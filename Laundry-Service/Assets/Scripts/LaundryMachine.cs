using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaundryMachine : MonoBehaviour
{

    public int _fullLimit;
    public int _addInMachine;
    public static bool isFull;

    public static int _tagChanger;

    //timer
    public float _time;
    private float _timeCheck;
    void Start()
    {
        _timeCheck = _time;
        _tagChanger = 0;
    }

    void Update()
    {
        TimerAndSystem();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DirtyUnfoldedInMachine" && _addInMachine<_fullLimit)
        {
            _addInMachine += 1;
            if (_addInMachine == _fullLimit)
            {
                isFull = true;
                transform.gameObject.tag = "InvalidDrop";
            }
        }
        if (collision.gameObject.tag == "DirtyUnfolded" && _tagChanger == 1)
        {
            transform.gameObject.tag = "ValidDrop";
        }
    }

    public void TagChanger()
    {
        _tagChanger = 1;
    }

    public void TimerAndSystem()
    {
        if (_tagChanger == 1)
        {
            _time -= Time.deltaTime;
            if (_time<=0)
            {

            }
        }
    }

   
}
