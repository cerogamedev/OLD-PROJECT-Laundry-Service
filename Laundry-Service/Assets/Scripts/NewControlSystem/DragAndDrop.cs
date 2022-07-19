using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public GameObject myCanvasAsGO;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    //control to which slot accept to cloth
    public int id;
    private Vector2 initPos;

    //control to draggable
    public int _setActiveCloth = 1;

    private void Start()
    {
        myCanvasAsGO = GameObject.Find("InGame-Canva");
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        myCanvas = myCanvasAsGO.GetComponent<Canvas>();
    }
    private void Update()
    {
        
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
        }
        if (collision.name == "Washer")
        {
            id = 2;
        }
        if (collision.name == "Rope")
        {
            id = 3;
        }

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Washer")
        {
            _setActiveCloth = 0;
            StartCoroutine(wait(10f));

        }

        if (collider.name == "Rope")
        {
            _setActiveCloth = 0;
            StartCoroutine(wait(3f));

        }

        if (collider.name == "Done_Basket")
        {
            _setActiveCloth = 0;
        }

    }

    public IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        _setActiveCloth = 1;
    }

  
}
