using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Basket")
        {
            transform.gameObject.tag = "DirtyUnfolded";
            Basket._spawnCounter -= 1;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Laundry-Machine" && LaundryMachine._tagChanger == 1)
        {
            transform.gameObject.tag = "CleanWet";
        }
        
    }
}
