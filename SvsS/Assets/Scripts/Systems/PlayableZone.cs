using System;
using System.Collections;
using System.Collections.Generic;
using Card;
using Card.Data;
using Players;
using UnityEngine;

namespace Systems
{
    public class PlayableZone : MonoBehaviour
    {
        private PlayerController _playerController;
        private List<ParticleSystem> _particleSystems;

        public int TimeToShowCard;

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
                
                foreach (var particle in _card.Data.ParticleSystems)//кусок совсем плох, завтра придумаю что с эффектами делаю
                {
                     Instantiate(particle, _card.transform.position, Quaternion.identity);
                }
                Destroy(_card.gameObject);
            }
            else
            {
                _playerController.CurrentPlayer.Hand.AddCardToHand(_card);
            }
        }
    }
}