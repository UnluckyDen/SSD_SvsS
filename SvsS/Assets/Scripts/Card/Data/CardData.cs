using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "CardData",menuName = "Card Data",order = 0)]
    public class CardData : ScriptableObject
    {
        [System.Serializable]
        public struct CardSettings
        {
            public string name;
            public string description;
            public string manaCost;
            public Sprite sprite;
            
            
        }
    }
}