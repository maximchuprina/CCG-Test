using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static Card cardDrag;

    //UI
    private Image cardImage;
    private Text titleText, manaText, damageText, hpText;
    private Animator manaAnim, damageAnim, hpAnim, cardAnimator;

    //Variables
    private bool Initialized = false;
    private bool valuesSetes = false;
    private int mana, damage, hp;
    private string title;
    public void Setup(Sprite _sprite)
    {
        Initialize();

        mana = Random.Range(-2,10);
        damage = Random.Range(-2, 10);
        hp = Random.Range(1, 10);
        title = "Creature #" + Random.Range(0, 100);

        titleText.text = title;
        cardImage.sprite = _sprite;

        SetValues();
    }
    void Initialize()
    {
        if (!Initialized)
        {
            cardAnimator = GetComponent<Animator>();
            cardImage = transform.GetChild(0).GetComponent<Image>();
            titleText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
            manaText = transform.GetChild(2).GetChild(0).GetComponent<Text>();
            damageText = transform.GetChild(3).GetChild(0).GetComponent<Text>();
            hpText = transform.GetChild(4).GetChild(0).GetComponent<Text>();
            manaAnim = transform.GetChild(2).GetComponent<Animator>();
            damageAnim = transform.GetChild(3).GetComponent<Animator>();
            hpAnim = transform.GetChild(4).GetComponent<Animator>();
            Initialized = true;
        }
    }
    public void SetValues()
    {
        manaText.text = mana.ToString();
        damageText.text = damage.ToString();
        hpText.text = hp.ToString();

        valuesSetes = true;

        if (hp <= 0)
        {
            cardAnimator.Play("Disabling");
        }
    }
    public bool RandomizeCardValue()
    {
        if (valuesSetes)
        {
            int valueToChange = Random.Range(0, 3);
            switch (valueToChange)
            {
                case 0:
                    {
                        mana = Random.Range(-2, 10);
                        manaAnim.Play("ChangeValue");
                        break;
                    }
                case 1:
                    {
                        hp = Random.Range(-2, 10);
                        hpAnim.Play("ChangeValue");
                        break;
                    }
                case 2:
                    {
                        damage = Random.Range(-2, 10);
                        damageAnim.Play("ChangeValue");
                        break;
                    }
            }

            valuesSetes = false;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OnDisablingAnimation()
    {
        Destroy(gameObject);
    }
}
