using Card.Data;
using UnityEngine;

namespace Card
{
    public class CardInfo : MonoBehaviour
    {
        [SerializeField] private CardData cardData;

        public CardData Data
        {
            get => cardData;
            set => cardData = value;
        }
    }  
}