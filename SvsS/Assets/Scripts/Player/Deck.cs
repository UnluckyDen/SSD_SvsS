using Card.Data;
using System.Collections.Generic;

namespace Players
{
    public class Deck
    {
        public List<CardData> deckList;
        public Deck(List<CardData> deckList)
        {
            this.deckList = deckList;
        }
        /*public List<CardData> SetDeck()
        {
            
        }*/
    }
}
