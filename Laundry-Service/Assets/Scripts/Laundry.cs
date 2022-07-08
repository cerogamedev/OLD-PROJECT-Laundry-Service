using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laundry : Draggable
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
       
        if (collision.gameObject.name == "Laundry-Machine" )
        {
         
            transform.gameObject.tag = "DirtyUnfoldedInMachine";
            this.IsDragging = false;
            
            if(LaundryMachine.isFull){
            //Wait inside of machine
            float time = 0;
            while(time < 5){
            time += Time.deltaTime;
            }
            }
  

          // transform.gameObject.tag = "CleanWet";
        }
        
    }
}
