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


    public GameObject Washer;
    public GameObject Rope;
    public GameObject Done_Basket;

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
            Basket._spawnCounter -= 1;

        }
        if (collision.name == "Washer" && id == 1)
        {
            id = 2;
        }
        if (collision.name == "Rope" && id == 2)
        {
            id = 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Washer" && id == 1)
        {
            transform.localPosition = new Vector2(Washer.transform.position.x, Washer.transform.position.y);
            _setActiveCloth = 0;
            StartCoroutine(wait(10f));

        }

        if (collider.gameObject.name == "Rope" && id == 2)
        {
            transform.localPosition = new Vector2(Rope.transform.position.x, Rope.transform.position.y);
            _setActiveCloth = 0;
            StartCoroutine(wait(3f));

        }

        if (collider.gameObject.name == "Done_Basket" && id == 3)
        {
            _setActiveCloth = 0;
            Money.earnMoney(5);
            Destroy(this.gameObject);
        }

    }

    public IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        _setActiveCloth = 1;
    }

}
