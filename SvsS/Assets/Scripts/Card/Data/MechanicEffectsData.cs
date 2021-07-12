using System.Collections.Generic;
using Card.Mechanics;
using UnityEngine;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "MechanicsData", menuName = "Mechanic Data", order = 0)]
    public class MechanicEffectsData : ScriptableObject
    {
        [System.Serializable]
        public struct EffectsSettings
        {
            public int damageCount;
            public int healCount;
            public int manaCount;
            public int drawsCardCount;
            public CardData getTargetCard;
                
            public MechanicsTemplate mechanic;
        }

        public List<EffectsSettings> effectsSettingsList;
    }
}