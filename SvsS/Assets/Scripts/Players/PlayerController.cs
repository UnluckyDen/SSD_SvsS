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

        private CardMover cardMover;
        private ClickAndDragController clickAndDragController;


        //количество единиц маны игрока на старте каждого раунда
        private int currentPlayerMana;
        
        private void Start()
        {
            cardMover = gameObject.GetComponent<CardMover>();
            clickAndDragController = gameObject.GetComponent<ClickAndDragController>();
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
            CurrentPlayer.IsAbleToInteract = false;
        }
        public void CurrentPlayerActivity()
        {
            Debug.Log("CurrentPlayerActivity was called");
            CurrentPlayer.IsAbleToInteract = true;
            SwitchTurnManaSetup();
            CurrentPlayer.Deck.DrawCard();
        }
        private void SwitchTurnManaSetup()
        {
            CurrentPlayer.ManaToGive += AddedManaPerTurn;
            CurrentPlayer.ManaSystem.SubtractMana(CurrentPlayer.ManaSystem.CurrentMana);
            CurrentPlayer.ManaSystem.AddMana(CurrentPlayer.ManaToGive);
        }
    }
}