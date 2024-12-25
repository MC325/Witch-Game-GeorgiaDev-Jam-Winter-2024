using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using WCG;

public class PlayField : MonoBehaviour
{
    [SerializeField] public float FieldWidth = 140.0f;

    public List<CardPrefab> Cards = new();

    [SerializeField] private HandManager _HandManager;

    [SerializeField] private CustomerManager _CustomerManager;

    // Start is called before the first frame update
    void Start()
    {
        CardPrefab.Interact += RemoveFromField;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCardToField(CardPrefab card)
    {
        Cards.Add(card);
        card.IsInField = true;
        Vector3 delta = new Vector3(-FieldWidth / 2.0f + FieldWidth * Cards.Count / 3.0f, 0, 0);
        card.Move(transform.position + delta);
    }

    public void RemoveFromField(CardPrefab card)
    {
        if (card.IsInField)
        {
            Cards.Remove(card);
            card.IsInField = false;
            _HandManager.AddCard(card);
        }
    }

    public void Brew()
    {
        List<IngredientType> ingredients = new();
        foreach (var card in Cards) {
            ingredients.Add(card.Ingredient);
        }

        IngredientType[] selectedIngredientCombo;
        PotionType selectedPotionType = PotionType.None;

        foreach(var ingredientCombo in PlayerState.POTION_INGREDIENTS.Keys)
        {
            if (ingredients[0] == ingredientCombo[0] &&
                ingredients[1] == ingredientCombo[1] &&
                ingredients[2] == ingredientCombo[2])
            {
                selectedIngredientCombo = ingredientCombo;
                selectedPotionType = PlayerState.POTION_INGREDIENTS[selectedIngredientCombo];
                Debug.Log(selectedPotionType.ToString());
                break;
            }
        }

        if (CustomerManager.CurrentCustomer.Solution.Contains(selectedPotionType))
        {
            PlayerState.NNMeter++;
        } else if (CustomerManager.CurrentCustomer.Problem.Contains(selectedPotionType))
        {
            PlayerState.NNMeter -= 2;
        }
        Debug.Log(PlayerState.NNMeter);

        _CustomerManager.ChangeCustomer();

        ClearField();
    }

    private void ClearField()
    {
        foreach (var card in Cards)
        {
            Destroy(card.gameObject);
        }
        Cards.Clear();
    }

   /* private IngredientType[] SortIngredients(List<IngredientType> ingredients)
    {
        IngredientType[] sorted = ingredients.OrderBy(x => (int) x).ToArray();
        return sorted;
    }*/
}
