using System;
using Card;
using Card.Data;
using UnityEngine;

namespace Systems
{
    public class PlayableZone : MonoBehaviour
    {
        public delegate void PlayableZoneHandler(CardData message);

        public event PlayableZoneHandler CardIsPlayed;

        private CardHandler _card;

        private void Update()
        {
            if (GetComponentInChildren<CardHandler>() == null) return;
            _card = GetComponentInChildren<CardHandler>();
            CardPlayed();
            Destroy(_card.gameObject);
        }

        public void CardPlayed()
        {
            //Сюда поуманому вытащить картдату из разыгранной карты
            CardIsPlayed?.Invoke(_card.Data);
        }
    }
}