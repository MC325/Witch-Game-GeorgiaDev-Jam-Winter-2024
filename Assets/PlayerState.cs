using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using WCG;

public class PlayerState : MonoBehaviour
{
    public static PlayerState Instance { get; private set; }

    public static int Day = 1;

    public static int NNMeter = 0;

    public static int Money = 0;

    public static Dictionary<IngredientType[], PotionType> POTION_INGREDIENTS = new()
    {
        { new IngredientType[] {IngredientType.WyvernHorn, IngredientType.MoonmothScales, IngredientType.FiveLeafClover}, PotionType.Flying },
        { new IngredientType[] {IngredientType.EverlilyRoot, IngredientType.MoonmothScales, IngredientType.CatspiderVenom}, PotionType.Invisibility },
        { new IngredientType[] {IngredientType.EverlilyRoot, IngredientType.WyvernHorn, IngredientType.}, PotionType.Strength },
    };

    private void Awake()
    {
        // Initialize singleton instance
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
