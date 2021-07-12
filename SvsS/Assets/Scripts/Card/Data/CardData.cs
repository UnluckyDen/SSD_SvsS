using System.Collections.Generic;
using UnityEngine;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "CardData",menuName = "Card Data",order = 0)]
    public class CardData : ScriptableObject
    {
            public new string name;
            public string description;
            public int manaCost;
            public Sprite sprite;
            public GameObject cardPrefab;
            
            public MechanicsData cardMechanic;
    }
}