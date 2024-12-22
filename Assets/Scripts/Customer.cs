using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WCG
{
    [CreateAssetMenu]
    public class Customer : ScriptableObject
    {
        public string Description;
        public PotionType[] Solution;
        public PotionType[] Problem;
    }

    public enum PotionType
    {
        None = -1,
        Flying,
        Bomb,
        Fire,
        Healing,
        Acid,
        Love,
        Invisibility,
        Sleep,
        Light,
        Luck,
        Strength,
        Growth,
        Frost,
        Speed
    }
}