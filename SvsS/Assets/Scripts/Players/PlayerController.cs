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
        private CardMover cardMover;
        private ClickAndDragController clickAndDragController;
      

        //���������� ������ ���� ������ �� ������ ������� ������
        private int currentPlayerMana;
        
        private void Start()
        {
            FirstPlayerSetup();
        }
        private void FirstPlayerSetup()
        {
            Players[FirstPlayerID].ManaToGive++;
            Players[FirstPlayerID].IsAbleToInteract = true;
            Players[FirstPlayerID].Deck.DrawCard();
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