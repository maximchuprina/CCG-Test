using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static CardDrag cardDrag;

    Canvas myCanvas;
    CanvasGroup myCanvasGroup;
    Transform startParent;
    Vector3 startPosition;

    void Awake()
    {
        myCanvas = GetComponent<Canvas>();
        myCanvasGroup = GetComponent<CanvasGroup>();
    }
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        cardDrag = this;
        myCanvas.sortingOrder = 2;

        startParent = transform.parent;
        startPosition = transform.position;

        myCanvasGroup.blocksRaycasts = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    { 
        cardDrag = null;
        myCanvas.sortingOrder = 1;

        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

        myCanvasGroup.blocksRaycasts = true;
    }
}
