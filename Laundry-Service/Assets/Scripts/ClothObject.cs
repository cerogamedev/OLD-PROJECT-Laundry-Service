using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothObject : MonoBehaviour
{
    public GameObject Washer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Washer")
        {
            transform.localPosition = new Vector2 (Washer.transform.position.x, Washer.transform.position.y);
           
        }
    }


}
