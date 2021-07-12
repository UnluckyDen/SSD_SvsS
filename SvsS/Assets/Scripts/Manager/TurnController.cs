using Players;
using UnityEngine;

namespace Manager
{
    public class TurnController : MonoBehaviour
    {
        public Animator turnManager;
        public Player player;
        private static readonly int PlayerFirst = Animator.StringToHash("PlayerFirst");

        public void Start()
        {
            turnManager.SetTrigger(PlayerFirst);
            player.healthSystem.OnDied += HealthSystem_OnDied;
        }

        private void HealthSystem_OnDied(object sender, System.EventArgs e)
        {
            if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                turnManager.SetTrigger("EnemyToEnd");
                Debug.Log("EnemyToEnd is Activated");
            }
            else if(turnManager.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn"))
            {
                turnManager.SetTrigger("PlayerToEnd");
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
                turnManager.SetTrigger("PlayerToEnemy");
            }
            else if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                turnManager.SetTrigger("EnemyToPlayer");
            }
        }
    }
   
}
