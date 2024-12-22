using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WCG
{
    [CreateAssetMenu]
    public class Card : ScriptableObject
    {
        public IngredientType Ingredient;
        public int Cost;
        public float Potency;
        public Color PotionColor;
    }

    public enum IngredientType
    {
        None = -1,
        FireflowerBuds,
        EverlilyRoot,
        WyvernHorn,
        MoonmothScales,
        CatspiderVenom,
        FiveLeafClover
    }
}
