using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothObject : MonoBehaviour
{
    public GameObject Washer;
    public GameObject Rope;
    public GameObject Done_Basket;

    public int id;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Washer")
        {
            transform.localPosition = new Vector2 (Washer.transform.position.x, Washer.transform.position.y);
           
        }

        else if (collision.gameObject.name == "Rope")
        {
            transform.localPosition = new Vector2(Rope.transform.position.x, Rope.transform.position.y);

        }

        else if (collision.gameObject.name == "Done_Basket")
        {
  
            transform.localPosition = new Vector2(Done_Basket.transform.position.x, Done_Basket.transform.position.y);
            Money.earnMoney(5);
            Destroy(this.gameObject);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Basket._spawnCounter -= 1;
    }

}
