using System;
using System.Collections.Generic;
using System.Linq;
using Card;
using UnityEngine;
using UnityEngine.Serialization;

namespace Players.Hand
{
    public class Hand : MonoBehaviour
    {
        public List<GameObject> CardsHolders;
        public GameObject CardHolderPrefab;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            CardInHandController();
        }

        public void AddCardToHand(CardInfo card)
        {
            var cardHolder = Instantiate(CardHolderPrefab, Vector3.zero, Quaternion.identity);
            
            //
            cardHolder.transform.SetParent(gameObject.transform);
            cardHolder.transform.localPosition = Vector3.zero;
            cardHolder.transform.localRotation = transform.localRotation;
            cardHolder.transform.localScale = gameObject.transform.localScale;
            
            card.gameObject.transform.SetParent(cardHolder.transform);
            card.transform.localEulerAngles = new Vector3(-90,0,0); 
            card.transform.localPosition = cardHolder.transform.position;
            card.transform.localScale = new Vector3(93,93,93);
            
            CardsHolders.Add(cardHolder);
        }

        private void CardInHandController()
        {
            foreach (var cardsHolder in CardsHolders.Where(cardsHolder =>
                cardsHolder.GetComponentInChildren<CardInfo>() == null))
            {
                CardsHolders.Remove(cardsHolder);
                //Destroy(cardsHolder);
                break;
            }
        }
    }
}