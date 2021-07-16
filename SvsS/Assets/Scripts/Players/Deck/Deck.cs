using System;
using System.Collections.Generic;
using System.Linq;
using Systems;
using Card;
using Card.Data;
using UnityEngine;

namespace Players.Deck
{
    [RequireComponent(typeof(CardCreator))]
    public class Deck : MonoBehaviour
    {
        public Player DeckOwner;
        private CardCreator _cardCreator;

        public bool ShuffleOnStart;
        [SerializeField] private List<CardData> _cardDatas;


        private void Start()
        {
            if (ShuffleOnStart) ShuffleDeck();
            _cardCreator = GetComponent<CardCreator>();
        }


        private void ShuffleDeck()
        {
            var listResult = _cardDatas.OrderBy(x => Guid.NewGuid().ToString()).ToList();
            _cardDatas = listResult;
        }

        public void DrawCard()
        {
            if (_cardDatas.Count <= 0) return;
            var card = _cardCreator.CreateCard(_cardDatas[0]);
            DeckOwner.Hand.AddCardToHand(card.GetComponent<CardInfo>());
            _cardDatas.Remove(_cardDatas[0]);
        }
    }
}