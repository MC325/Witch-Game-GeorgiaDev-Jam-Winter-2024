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

    public static Dictionary<IngredientType[], PotionType> POTION_INGREDIENTS = new(new IngredientListComparer())
    {
        { new IngredientType[] {IngredientType.MoonmothScales, IngredientType.WyvernHorn, IngredientType.FiveLeafClover}, PotionType.Flying },
        { new IngredientType[] {IngredientType.EverlilyRoot, IngredientType.CatspiderVenom, IngredientType.MoonmothScales}, PotionType.Invisibility },
        { new IngredientType[] {IngredientType.WyvernHorn, IngredientType.CatspiderVenom, IngredientType.EverlilyRoot}, PotionType.Strength },
        { new IngredientType[] {IngredientType.WyvernHorn, IngredientType.FireflowerBuds, IngredientType.CatspiderVenom}, PotionType.Bomb },
        { new IngredientType[] {IngredientType.MoonmothScales, IngredientType.FireflowerBuds, IngredientType.CatspiderVenom}, PotionType.Love },
        { new IngredientType[] {IngredientType.CatspiderVenom, IngredientType.FireflowerBuds, IngredientType.FiveLeafClover}, PotionType.Acid },
        { new IngredientType[] {IngredientType.FiveLeafClover, IngredientType.MoonmothScales, IngredientType.EverlilyRoot}, PotionType.Dexterity },
        { new IngredientType[] {IngredientType.FireflowerBuds, IngredientType.MoonmothScales, IngredientType.CatspiderVenom}, PotionType.Fire },
        { new IngredientType[] {IngredientType.MoonmothScales, IngredientType.EverlilyRoot, IngredientType.WyvernHorn}, PotionType.Frost },
        { new IngredientType[] {IngredientType.EverlilyRoot, IngredientType.CatspiderVenom, IngredientType.FiveLeafClover}, PotionType.Healing },
        { new IngredientType[] {IngredientType.MoonmothScales, IngredientType.FiveLeafClover, IngredientType.FireflowerBuds}, PotionType.Light },
        { new IngredientType[] {IngredientType.FiveLeafClover, IngredientType.MoonmothScales, IngredientType.WyvernHorn}, PotionType.Speed },
        { new IngredientType[] {IngredientType.EverlilyRoot, IngredientType.MoonmothScales, IngredientType.FireflowerBuds}, PotionType.Growth },
        { new IngredientType[] {IngredientType.CatspiderVenom, IngredientType.EverlilyRoot, IngredientType.MoonmothScales}, PotionType.Sleep },
        { new IngredientType[] {IngredientType.FiveLeafClover, IngredientType.EverlilyRoot, IngredientType.MoonmothScales}, PotionType.Luck },
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
