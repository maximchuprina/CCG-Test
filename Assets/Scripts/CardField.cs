using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardField : MonoBehaviour, IDropHandler
{
    void IDropHandler.OnDrop(PointerEventData eventData)
    {
        if(CardDrag.cardDrag != null)
        {
            CardDrag.cardDrag.transform.SetParent(transform);
        }
    }
}
