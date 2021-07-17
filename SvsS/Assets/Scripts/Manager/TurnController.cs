using Players;
using UnityEngine;
using System.Collections.Generic;

namespace Manager
{
    public class TurnController : MonoBehaviour
    {
        public Animator turnManager;
        private List<Player> players;
        public PlayerController PlayerController;
        private static readonly int PlayerFirst = Animator.StringToHash("PlayerFirst");
        private static readonly int EnemyFirst = Animator.StringToHash("EnemyFirst");
        private static readonly int PlayerToEnemy = Animator.StringToHash("PlayerToEnemy");
        private static readonly int EnemyToPlayer = Animator.StringToHash("EnemyToPlayer");
        private static readonly int PlayerToEnd = Animator.StringToHash("PlayerToEnd");
        private static readonly int EnemyToEnd = Animator.StringToHash("EnemyToEnd");

        private int currentState;
        public void Start()
        {   
            if(PlayerController.FirstPlayerID == 0)
                turnManager.SetTrigger(PlayerFirst);
            else
                turnManager.SetTrigger(EnemyFirst);

            for (int i = 0; i < players.Count; i++)
            {
                PlayerController.Players[i].HealthSystem.OnDied += HealthSystem_OnDied;
            }
        }
        private void HealthSystem_OnDied(Player player)
        {
            Debug.Log("OnDied event is happened");
            if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                turnManager.SetTrigger(EnemyToEnd);
                Debug.Log("EnemyToEnd is Activated");
            }
            else if(turnManager.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn"))
            {
                turnManager.SetTrigger(PlayerToEnd);
                Debug.Log("PlayerToEnd is Activated");
            }
        }

        public void Update()
        {
            //player does not contain playerHealthSystem attribute
            /*if (player.playerHealthSystem.GetHp() == 0)
        {
            turnManager.SetTrigger("PlayerToEnd");
        }*/
        }
        public void EndTurn()
        {
            if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn"))
            {
                turnManager.SetTrigger(PlayerToEnemy);
                PlayerController.SwitchActivePlayer();
                Debug.Log("Active player is: " + PlayerController.CurrentPlayer.gameObject.name);
            }
            else if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                turnManager.SetTrigger(EnemyToPlayer);
                PlayerController.SwitchActivePlayer();
                Debug.Log("Active player is: " + PlayerController.CurrentPlayer.gameObject.name);
            }
        }
        public void OnDestroy()
        {
            for (int i = 0; i < players.Count; i++)
            {
                PlayerController.Players[i].HealthSystem.OnDied -= HealthSystem_OnDied;
            }
        }
        public int GetCurrentState()
        {
            return turnManager.GetCurrentAnimatorStateInfo(0).fullPathHash;
        }

    }
   
}
