using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public GameObject myCanvasAsGO;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    //control to which slot accept to cloth
    public int id;
    private Vector2 initPos;

    public Image washImage;
    //control to draggable
    public int _setActiveCloth = 1;


    public GameObject Washer;
    public GameObject Rope;
    public GameObject Done_Basket;

    public static int countWasher = 0;
    public static int countRope = 0;

    private void Start()
    {
        myCanvasAsGO = GameObject.Find("InGame-Canva");
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        myCanvas = myCanvasAsGO.GetComponent<Canvas>();

        Washer = GameObject.FindGameObjectWithTag("Washer");
        Rope = GameObject.FindGameObjectWithTag("Rope");
        Done_Basket = GameObject.FindGameObjectWithTag("Done_Basket");
    }

 
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_setActiveCloth == 1)
        {
            rectTransform.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
       
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        initPos = transform.position;


    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void ResetPosition()
    {
        transform.position = initPos;
    }

    //update id
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Basket")
        {
            id = 1;
            Basket._spawnCounter -= 1;

        }
        if (collision.name == "Washer" && id == 1)
        {
            id = 2;
            countWasher--;
    
        }
        if (collision.name == "Rope" && id == 2)
        {
            id = 3;
            countRope--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Washer" && id == 1 && countWasher < 3)
        {
            transform.localPosition = new Vector2(Washer.transform.localPosition.x, Washer.transform.localPosition.y);
            _setActiveCloth = 0;
            washImage.enabled = false;
            StartCoroutine(waitWM(3f));
            countWasher++;
            //washImage.enabled = true;

            if (countWasher == 3)
            {
                Debug.Log("Machine is full");
            }
        }

        if (collider.gameObject.name == "Rope" && id == 2)
        {
            if (countRope == 0)
            {
                transform.localPosition = new Vector2(Rope.transform.localPosition.x, Rope.transform.localPosition.y - 80);

            }
            else if (countRope == 1)
            {
                transform.localPosition = new Vector2(Rope.transform.localPosition.x + 200, Rope.transform.localPosition.y - 80);

            }
            else if (countRope == 2)
            {
                transform.localPosition = new Vector2(Rope.transform.localPosition.x - 200, Rope.transform.localPosition.y - 80);

            }
            _setActiveCloth = 0;
            StartCoroutine(wait(3f));
            countRope++;

            if (countRope == 3)
            {
                Debug.Log("Rope is full");
            }
        }

        if (collider.gameObject.name == "Done_Basket" && id == 3)
        {
            _setActiveCloth = 0;
            Money.earnMoney(5);
            Destroy(this.gameObject);
        }

    }

    public IEnumerator waitWM(float time)
    {
        yield return new WaitForSeconds(time);
        _setActiveCloth = 1;
        washImage.enabled = true;

    }

    public IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        _setActiveCloth = 1;
    }



}
