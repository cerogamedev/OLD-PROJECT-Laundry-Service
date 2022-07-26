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
    public static int ropeState = 0;

    public static float washerTime;
    public static float ropeTime;

    private Animator anim;

    private void Start()
    {
        myCanvasAsGO = GameObject.Find("InGame-Canva");
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        myCanvas = myCanvasAsGO.GetComponent<Canvas>();

        Washer = GameObject.FindGameObjectWithTag("Washer");
        Rope = GameObject.FindGameObjectWithTag("Rope");
        Done_Basket = GameObject.FindGameObjectWithTag("Done_Basket");

        anim = GetComponent<Animator>();
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
            //şunu nasıl ekleriz?
            //eğer dokunulan cloth'un locationı Rope.transform.localPosition.x ise state'i 0 yap.
            // eğer Rope.transform.localPosition.x + 200 ise staete'i 1 yap
            // eğer Rope.transform.localPosition.x - 200 ise state'i 0 yap.
            //buraya ekleyemiyoruz çünü on exit dediği için exit sırasında location x değişmiş oluyor
            //on touch gibi bir şey lazım.
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name== "Washer" && id == 1 && countWasher < 3)
        {
            transform.localPosition = new Vector2(Washer.transform.localPosition.x, Washer.transform.localPosition.y);
            _setActiveCloth = 0;
            washImage.enabled = false;
            StartCoroutine(waitWM(washerTime));
            countWasher++;

            if (countWasher == 3)
            {
                Debug.Log("Machine is full");
            }

            anim.SetTrigger("Wet");
        }

        if (collider.gameObject.name == "Rope" && id == 2)
        {

            if (ropeState == 0) 
            {
                transform.localPosition = new Vector2(Rope.transform.localPosition.x , Rope.transform.localPosition.y - 80);
                ropeState = 1;
                Debug.Log(ropeState);

            }
            else if (ropeState == 1)
            {
                transform.localPosition = new Vector2(Rope.transform.localPosition.x + 200 , Rope.transform.localPosition.y - 80);
                ropeState = -1;
                Debug.Log(ropeState);

            }
            else if (ropeState == -1)
            {
                transform.localPosition = new Vector2(Rope.transform.localPosition.x - 200, Rope.transform.localPosition.y - 80);
                ropeState = 0;
                Debug.Log(ropeState);

            }

            _setActiveCloth = 0;
            StartCoroutine(wait(ropeTime));
        }

        if (collider.gameObject.name == "Done_Basket" && id == 3)
        {
            _setActiveCloth = 0;
            Money.earnMoney(5);
            ShopSystem.SaveGame();
            Destroy(this.gameObject);
        }

    }

    public IEnumerator waitWM(float time)
    {
        yield return new WaitForSeconds(time);
        _setActiveCloth = 1;
        washImage.enabled = true;
        countWasher--;
    }

    public IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        _setActiveCloth = 1;
        anim.SetTrigger("Clean");
    }



}
