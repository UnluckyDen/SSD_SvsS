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
        [SerializeField] private float _timeToShow = 1f;
        [SerializeField] private GameObject _canvas;


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
                
                _card.transform.SetParent(_canvas.transform);
                _playerController.CurrentPlayer.ChelAnimator.SetAnimationPlayCard();

                _coroutine = WaitAndDestroy(_timeToShow,_card.gameObject);
                StartCoroutine(_coroutine);
            }
            else
            {
                _playerController.CurrentPlayer.Hand.AddCardToHand(_card);
            }
        }
        
        private IEnumerator _coroutine;
        private IEnumerator WaitAndDestroy(float waitTime,GameObject card)
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                Destroy(card);
            }
        }
    }
}