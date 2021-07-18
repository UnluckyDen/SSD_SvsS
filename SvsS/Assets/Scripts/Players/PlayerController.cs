using System.Collections.Generic;
using Systems.MoveCard;
using UnityEngine;

namespace Players
{
    public class PlayerController : MonoBehaviour
    {
        public List<Player> Players;
        [Range(0, 1)] public int FirstPlayerID; 
        public Player CurrentPlayer => Players[FirstPlayerID];

        public int AddedManaPerTurn;
        public int AmountOfCardsOnStart;

        private int AmountOfTurns = 0;
      
        private void Start()
        {
            FirstPlayerSetup();
            //охуенно я придумал да
            for (int i = 0; i < Players.Count; i++)
            {
                for (int j = 0; j < AmountOfCardsOnStart; j++)
                {
                    Players[i].Deck.DrawCard();
                }
            }
        }
        private void FirstPlayerSetup()
        {
            Players[FirstPlayerID].ManaToGive++;
            Players[FirstPlayerID].IsAbleToInteract = true;
        }
        public void SwitchActivePlayer()
        { 
            var firstPlayer = Players[FirstPlayerID];
            for (var i = 0; i < Players.Count - 1; i++)
            {
                Players[i] = Players[i + 1];
            }

            Players[Players.Count - 1] = firstPlayer;
            CurrentPlayerActivity();            
            AmountOfTurns++;
        }

        private void CurrentPlayerActivity()
        {
            SwitchTurnManaSetup();
            if (AmountOfTurns > 0)
            {
                CurrentPlayer.Deck.DrawCard();
            }
            CurrentPlayer.IsAbleToInteract = true;
        }
        private void SwitchTurnManaSetup()
        {
            CurrentPlayer.ManaToGive += AddedManaPerTurn;
            CurrentPlayer.ManaSystem.SubtractMana(CurrentPlayer.ManaSystem.CurrentMana);
            CurrentPlayer.ManaSystem.AddMana(CurrentPlayer.ManaToGive);
        }
    }
}