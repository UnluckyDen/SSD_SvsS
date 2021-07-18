using System;
using System.Collections.Generic;
using System.Linq;
using Card;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Players.Hand
{
    public class Hand : MonoBehaviour
    {
        public GameObject CardHolderPrefab;
        private List<GameObject> _cardHolders = new List<GameObject>();

        public List<GameObject> CardHolders => _cardHolders;

        void Update()
        {
            CardInHandController();
        }

        public void AddCardToHand(CardInfo card)
        {
            if (card == null) return;
            var cardHolder = Instantiate(CardHolderPrefab, Vector3.zero, Quaternion.identity);

            cardHolder.transform.SetParent(gameObject.transform);
            cardHolder.transform.localPosition = Vector3.zero;
            cardHolder.transform.localRotation = transform.localRotation;
            cardHolder.transform.localScale = gameObject.transform.localScale;

            var cardTransform = card.transform;
            cardTransform.SetParent(cardHolder.transform);
            cardTransform.localEulerAngles = new Vector3(-90, 0, 0);
            cardTransform.localPosition = cardHolder.transform.position;
            cardTransform.localScale = new Vector3(93, 93, 93);

            _cardHolders.Add(cardHolder);
        }

        public void DropRandomCard()
        {
            if (_cardHolders.Count == 0) return;
            var number = Random.Range(0, _cardHolders.Count - 1);
            var cardInfo = _cardHolders[number].GetComponentInChildren<CardInfo>();
            _cardHolders.Remove(_cardHolders[number]);
            if(cardInfo == null) return;
            Destroy(cardInfo.gameObject);
        }

        private void CardInHandController()
        {
            foreach (var cardsHolder in _cardHolders.Where(cardsHolder =>
                cardsHolder == null))
            {
                _cardHolders.Remove(cardsHolder);
                break;
            }
        }
    }
}