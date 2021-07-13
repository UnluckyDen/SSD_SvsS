using Card.Data;
using UnityEngine;

namespace Systems
{
    public class PlayableZone : MonoBehaviour
    {
        public delegate void PlayableZoneHandler(CardData message);

        public event PlayableZoneHandler CardIsPlayed;

        public void CardPlayed()
        {
            //Сюда поуманому вытащить картдату из разыгранной карты
            CardIsPlayed?.Invoke(new CardData());
        }
    }
}
