using System;
using Card;
using Card.Data;
using Players;
using UnityEngine;

namespace Systems
{
    public class PlayableZone : MonoBehaviour
    {
        private PlayerController _playerController;

        public delegate void PlayableZoneHandler(CardData message);

        public event PlayableZoneHandler CardIsPlayed;

        private CardInfo _card;

        private void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
        }

        private void Update()
        {
            CardPlayed();
        }

        private void CardPlayed()
        {
            if (GetComponentInChildren<CardInfo>() == null) return;
            _card = GetComponentInChildren<CardInfo>();
            if (_playerController.CurrentPlayer.ManaSystem.CurrentMana >= _card.Data.manaCost)
            {
                _playerController.CurrentPlayer.ManaSystem.SubtractMana(_card.Data.manaCost);
                CardIsPlayed?.Invoke(_card.Data);
                Destroy(_card.gameObject);
            }
            else
            {
                _playerController.CurrentPlayer.Hand.AddCardToHand(_card);
            }
        }
    }
}