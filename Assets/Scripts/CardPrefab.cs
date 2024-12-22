using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WCG;

public class CardPrefab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] public IngredientType Ingredient;
    [SerializeField] public Image IngredientImage;
    [SerializeField] public Card IngredientCard;
    [SerializeField] public TMP_Text IngredientName;
    [SerializeField] public TMP_Text Potency;
    [SerializeField] public Sprite[] IngredientImages;
    [SerializeField] public Card[] IngredientCards;

    public delegate void CardDelegate(CardPrefab card);

    public event CardDelegate Interact;

    public bool IsInHand = false;

    public float PotencyModifier = 1.0f;


    private void Start()
    {
        UpdateCard();
    }

    public void SetIngredient(IngredientType ingredient)
    {
        Ingredient = ingredient;
        UpdateCard();
    }

    public void UpdateCard()
    {
        IngredientCard = IngredientCards[(int) Ingredient];
        IngredientName.text = IngredientCard.name;
        Potency.text = $"{(IngredientCard.Potency * PotencyModifier).ToString("0.00")}x";
        IngredientImage.sprite = IngredientImages[(int) Ingredient];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsInHand)
        {
            transform.position -= Vector3.forward * 10;
            transform.position += Vector3.up * 10;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsInHand)
        {
            transform.position += Vector3.forward * 10;
            transform.position -= Vector3.up * 10;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Interact(this);
    }

    public void Move(Vector3 position)
    {
        transform.position = position;
    }
}
