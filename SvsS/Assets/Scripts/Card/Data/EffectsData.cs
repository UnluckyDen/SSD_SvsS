using System.Collections.Generic;
using Card.Effects;
using UnityEngine;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "EffectsData", menuName = "Effects Data", order = 0)]
    public class EffectsData : ScriptableObject
    {
        [System.Serializable]
        public struct EffectsSettings
        {
            public int damageCount;
            public int healCount;
            public int manaCount;
            public int drawsCardCount;
            
                
            public EffectsTemplate effect;
        }

        public List<EffectsSettings> effectsSettingsList;
    }
}