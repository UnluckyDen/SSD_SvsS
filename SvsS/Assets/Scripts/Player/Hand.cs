
using System.Collections.Generic;
using UnityEngine;
using Card.Data;
using System.Linq;

namespace Players
{
    public class Hand 
    {
        public List<CardData> handList;
        public List<CardData> deckList;
        public Hand(List<CardData> hand, List<CardData> deck)
        {
            handList = hand;
            deckList = deck;
        }
        public void ShowCards(List<CardData> cards)
        {
            //здесь будет код, показывающий карты на UI
        }
        public void DrawCard()
        {          
            CardData addedCard = deckList.First();
                handList.Add(addedCard);
                deckList.Remove(deckList.First());         
        }
        public void DrawOnStart()
        {
            for(int i = 0; i < 6; i++)
            {
                DrawCard();
            }
        }
    }
}
