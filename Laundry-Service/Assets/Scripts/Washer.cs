using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Washer : MonoBehaviour
{
    public Image machineFull;
    void Start()
    {
        machineFull.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (DragAndDrop.countWasher != 0)
        {
            StartCoroutine(Tremble());
        }

        if (DragAndDrop.countWasher ==3)
        {
            machineFull.enabled = true;
        }
        else
        {
            machineFull.enabled = false;
        }

    }
    IEnumerator Tremble()
    {
        for (int i = 0; i < 10; i++)
        {
            transform.localPosition += new Vector3(5f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition -= new Vector3(5f, 0, 0);
            yield return new WaitForSeconds(0.01f);
            transform.localPosition = new Vector2(2, 305);
        }
    }
}
