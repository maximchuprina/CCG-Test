using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardValue : MonoBehaviour
{
    Card myCard;

    public void SetValue()
    {
        if (myCard == null)
            myCard = GetComponentInParent<Card>();

        myCard.SetValues();
    }
}
