using Card.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Card
{
    public class CardHandler : MonoBehaviour
    {
        [SerializeField] private CardData cardData;

        public CardData Data
        {
            get => cardData;
            set => cardData = value;
        }
    }
}
