using System.Collections.Generic;
using Systems.MoveCard;
using UnityEngine;
using UI;

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

        public GameObject YourTurnView;
        public GameObject EnemyTurnView;
        public GameObject TurnButton;
        
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
            if(Players[FirstPlayerID].IsPlayer)
            {
                YourTurnView.SetActive(true);
                EnemyTurnView.SetActive(false);
            }
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
            if(CurrentPlayer.IsPlayer)
            {
                Debug.Log("CurrentPlayer.IsPlayer" + CurrentPlayer.IsPlayer.ToString());
                YourTurnView.SetActive(true);
                EnemyTurnView.SetActive(false);
                TurnButton.SetActive(true);
            }
            else
            {
                Debug.Log("CurrentPlayer.IsPlayer" + CurrentPlayer.IsPlayer.ToString());
                YourTurnView.SetActive(false);
                EnemyTurnView.SetActive(true);
                TurnButton.SetActive(false);
            }
        }
        private void SwitchTurnManaSetup()
        {
            CurrentPlayer.ManaToGive += AddedManaPerTurn;
            CurrentPlayer.ManaSystem.SubtractMana(CurrentPlayer.ManaSystem.CurrentMana);
            CurrentPlayer.ManaSystem.AddMana(CurrentPlayer.ManaToGive);
        }
    }
}