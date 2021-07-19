using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Systems;
using Card;
using Manager;
using Players;
using UnityEngine;
using UnityEngine.Events;

namespace Stupid_AI
{
    public class GeniusAI : MonoBehaviour
    {
        private Player _aIPlayer;
        private List<GameObject> _cardList;
        private PlayableZone _playableZone;
        private GameObject _mostValueCard;
        private PlayerController _playerController;
        private TurnController _turnController;
        private Animator _statesOfAi;
        private PigPlaySound _pigPlaySound;

        private float _cardValue;

        private static readonly int CanPlay = Animator.StringToHash("CanPlayCard");

        [SerializeField] private int _manaIndex;
        [SerializeField] private int _damageIndex;
        [SerializeField] private int _healIndex;
        [SerializeField] private int _drawCardIndex;
        [SerializeField] private int _dropIndex;
        
        private void Start()
        {
            _pigPlaySound = FindObjectOfType<PigPlaySound>();
            _statesOfAi = GetComponent<Animator>();
            _turnController = FindObjectOfType<TurnController>();
            _turnController.OnTurnChanged += AITurnChecker;
            _aIPlayer = GetComponent<Player>();
            _cardList = _aIPlayer.Hand.CardHolders;
            _playableZone = FindObjectOfType<PlayableZone>();
            _playerController = FindObjectOfType<PlayerController>();
        }


        public void AITurnChecker(bool isPlayerTurn)
        {
            Debug.Log("startAITurn");
            _statesOfAi.SetBool("IsAiTurn", !isPlayerTurn);
        }

        private GameObject MostValueCard()
        {
            _mostValueCard = null;
            _cardValue = float.NegativeInfinity;
            foreach (var card in _cardList)
            {
                var currentValue = 0f;
                var cardData = card.GetComponentInChildren<CardInfo>().Data;

                if (cardData.manaCost > _aIPlayer.ManaSystem.CurrentMana) continue;

                //посчитать манавелью
                foreach (var changeMana in cardData.changeMana)
                {
                    currentValue += changeMana.GetValue() * _manaIndex;
                }

                //посчиать дамаг велью
                foreach (var addDamage in cardData.addDamages)
                {
                    currentValue += addDamage.GetValue() * _damageIndex;
                }

                //посчитать хил велью
                foreach (var addHeal in cardData.addHeals)
                {
                    currentValue += addHeal.GetValue() * _healIndex;
                }

                //посчитать добор карт велью
                foreach (var drawCard in cardData.drawCards)
                {
                    currentValue += drawCard.GetValue() * _drawCardIndex;
                }

                //посчитать сброс карт велью
                foreach (var dropCard in cardData.dropCards)
                {
                    currentValue -= dropCard.GetValue() * _dropIndex;
                }

                //делим велью на ману
                if (cardData.manaCost != 0)
                {
                    currentValue /= cardData.manaCost;
                }
                else //если бесплатно, то в двойне хотим, я бы даже сказал:"В квадрате"
                {
                    currentValue *= currentValue;
                }

                if (currentValue < _cardValue) continue;
                _cardValue = currentValue;
                _mostValueCard = card;
            }

            Debug.Log(_cardValue);
            return _mostValueCard;
        }

        public bool CanPlayCard()
        {
            if (!_cardList.Select(card => card.GetComponentInChildren<CardInfo>().Data)
                .Any(cardData => _aIPlayer.ManaSystem.CurrentMana >= cardData.manaCost)) return false;
            _statesOfAi.SetTrigger(CanPlay);
            return true;
        }

        public void PlayCard()
        {
            var card = _mostValueCard;
            if (card == null) return;
            card.transform.SetParent(_playableZone.transform);
            _cardList.Remove(card);
            card.transform.localScale = _playableZone.transform.localScale;
            card.transform.position = _playableZone.transform.position;
            card.transform.localEulerAngles = new Vector3(-0, 0, 0f);
        }

        private void EndTurn()
        {
            _turnController.EndTurn();
            _pigPlaySound.PlaySound();
        }
   

        private void OnDestroy()
        {
            _turnController.OnTurnChanged -= AITurnChecker;
        }
    }
}