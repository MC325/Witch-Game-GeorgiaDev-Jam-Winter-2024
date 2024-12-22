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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCardToField(CardPrefab card)
    {
        Cards.Add(card);
        Vector3 delta = new Vector3(-FieldWidth / 2.0f + FieldWidth * Cards.Count / 3.0f, 0, 0);
        card.Move(transform.position + delta);
    }

    public void RemoveFromField(CardPrefab card)
    {
        Cards.Remove(card);
        _HandManager.AddCard(card);
    }

    public void Brew()
    {
        List<IngredientType> ingredients = new();
        foreach (var card in Cards) {
            ingredients.Add(card.Ingredient);
        }
        IngredientType[] sorted = SortIngredients(ingredients);

        IngredientType[] selectedIngredientCombo;
        PotionType selectedPotionType;

        foreach(var ingredientCombo in PlayerState.POTION_INGREDIENTS.Keys)
        {
            if (sorted[0] == ingredientCombo[0] &&
                sorted[1] == ingredientCombo[1] &&
                sorted[2] == ingredientCombo[2])
            {
                selectedIngredientCombo = ingredientCombo;
                selectedPotionType = PlayerState.POTION_INGREDIENTS[selectedIngredientCombo];
                Debug.Log(selectedPotionType.ToString());
                break;
            }
        }
    }

    private IngredientType[] SortIngredients(List<IngredientType> ingredients)
    {
        IngredientType[] sorted = ingredients.OrderBy(x => (int) x).ToArray();
        return sorted;
    }
}
