using System;
using System.Collections.Generic;
using Card.Mechanics;
using UnityEngine;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "MechanicsData", menuName = "Mechanic Data", order = 0)]
    public class MechanicsData : ScriptableObject
    {
        // public int damageCount;
        // public int healCount;
        // public int manaCount;
        // public int drawsCardCount;
        // public CardData getTargetCard;
        [SerializeField] private List<AddDamage> _addDamages;
        [SerializeField] private List<AddHeal> _addHeals;
        [SerializeField] private List<GetCard> _getCards;
    }
}