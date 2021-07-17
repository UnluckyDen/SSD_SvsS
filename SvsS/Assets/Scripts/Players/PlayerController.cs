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
        }
        public void CurrentPlayerActivity()
        {
            Debug.Log("CurrentPlayerActivity was called");

            if(CurrentPlayer.IsPlayer)
            {
                Debug.Log("first if was reached");
                if (cardMover.enabled == false && clickAndDragController.enabled == false)
                {
                    cardMover.enabled = true;
                    clickAndDragController.enabled = true;
                    Debug.Log("cardMover enabled is" + cardMover.enabled.ToString() + " " + "cardMover enabled is" + clickAndDragController.enabled.ToString());
                }
            }
            else if(!CurrentPlayer.IsPlayer)
            {
                Debug.Log("second if was reached");
                cardMover.enabled = false;
                clickAndDragController.enabled = false;
                Debug.Log("cardMover enabled is" + cardMover.enabled.ToString() + " " + "cardMover enabled is" + clickAndDragController.enabled.ToString());
            }
            SwitchTurnManaSetup();
        }
        private void SwitchTurnManaSetup()
        {
            CurrentPlayer.ManaToGive += AddedManaPerTurn;
            CurrentPlayer.ManaSystem.SubtractMana(CurrentPlayer.ManaSystem.CurrentMana);
            CurrentPlayer.ManaSystem.AddMana(CurrentPlayer.ManaToGive);
        }
    }
}