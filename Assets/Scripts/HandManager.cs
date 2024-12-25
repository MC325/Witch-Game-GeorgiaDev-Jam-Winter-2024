using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using WCG;

public class HandManager : MonoBehaviour
{
    [SerializeField] public GameObject IngredientCard;

    [SerializeField] public float HandWidth = 350.0f;

    Dictionary<IngredientType, int> CardsInHand = new();

    List<CardPrefab> Cards = new();

    [SerializeField] private PlayField _PlayField;

    private void Awake()
    {
        CardPrefab.Interact += TransferToField;

        // Populate dictionary with empty entries
        for (int i = 0; i < 6; i++)
        {
            CardsInHand.Add((IngredientType)i, 0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Generate random ingredients in hand
        for (int i = 0; i < 9; i++)
        {
            IngredientType randomIngredient = (IngredientType)Random.Range(0, 6);
            AddCard(randomIngredient);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddCard(IngredientType ingredient)
    {
        var newCard = Instantiate(IngredientCard, transform.position, Quaternion.identity);
        var script = newCard.GetComponent<CardPrefab>();
        script.SetIngredient(ingredient);
        AddCard(script);
    }

    public void AddCard(CardPrefab card)
    {
        CardsInHand[card.Ingredient]++;
        card.IsInHand = true;

        Cards.Add(card);
        UpdateCardPositions();
    }

    public void RemoveCard(CardPrefab card)
    {
        CardsInHand[card.Ingredient]--;
        card.IsInHand = false;

        Cards.Remove(card);
        UpdateCardPositions();
    }

    public void TransferToField(CardPrefab card)
    {
        if (card.IsInHand && _PlayField.Cards.Count < 3)
        {
            RemoveCard(card);
            _PlayField.AddCardToField(card);
        }
    }

    /*public void RemoveCard(IngredientType ingredient)
    {
        if (CardsInHand[ingredient] > 0)
        {
            CardsInHand[ingredient]--;
        }
    }*/

    public void UpdateCardPositions()
    {
        for (int i = 0; i < Cards.Count; i++)
        {
            var card = Cards[i];
            Vector3 delta = new Vector3(-HandWidth / 2.0f + HandWidth * i / (float) Cards.Count, 0, 0);
            card.Move(transform.position + delta);

            Quaternion theta = Camera.main.transform.rotation * Quaternion.Euler(0, 10, 0);
            card.transform.rotation = theta;
        }
    }
}
