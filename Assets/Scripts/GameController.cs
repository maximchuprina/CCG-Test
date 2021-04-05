using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public Transform playerHand;

    //Game Params
    public int minCards, maxCards;

    //Randomizing Params
    int cardToRandomize = -1;
    bool randomizeLeftToRight = true;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        StartCoroutine(CreateCards());
    }

    #region Game Field
    IEnumerator CreateCards()
    {
        for (int i = 0; i < Random.Range(minCards,maxCards); i++)
        {
            WWW www = new WWW("https://picsum.photos/175/145");
            yield return www;
            CreateCard(Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0)));
        }
    }
    void CreateCard(Sprite _sprite)
    {
        Card newCard = Instantiate(Resources.Load<GameObject>("Card"), playerHand).GetComponent<Card>();
        newCard.Setup(_sprite);
    }
    #endregion

    #region Cards randomizing
    public void RandomizeCardValue()
    {
        if (NextCardToRandomize())
            playerHand.GetChild(cardToRandomize).GetComponent<Card>().RandomizeCardValue();
    }
    bool NextCardToRandomize()
    {
        if(playerHand.childCount == 0) //Can't randomize if doesn't has childs
        {
            return false;
        }
        else if (playerHand.childCount <= cardToRandomize) //Overlimit
        {
            cardToRandomize = playerHand.childCount - 1;
            return true;
        }
        else if (cardToRandomize == -1) //First time
        {
            cardToRandomize = 0;
            return true;
        }
        else
        {
            if (playerHand.childCount == 1) //Only one card in hand
            {
                cardToRandomize = 0;
            }
            else if (randomizeLeftToRight) //Left to right
            {
                if (cardToRandomize + 1 < playerHand.childCount)
                {
                    cardToRandomize++;
                }
                else
                {
                    cardToRandomize--;
                    randomizeLeftToRight = false;
                }
            }
            else //Right to left
            {
                if (cardToRandomize - 1 >= 0)
                {
                    cardToRandomize--;
                }
                else
                {
                    cardToRandomize++;
                    randomizeLeftToRight = true;
                }
            }

            return true;
        }
    }
    #endregion
}
