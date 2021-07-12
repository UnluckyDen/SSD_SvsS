using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "CardData",menuName = "Card Data",order = 0)]
    public class CardData : ScriptableObject
    {
            public new string name;
            public string description;
            public string manaCost;
            public Sprite sprite;
            public GameObject cardPrefab;
            
            public List<MechanicEffectsData> cardEffect;
    }
}