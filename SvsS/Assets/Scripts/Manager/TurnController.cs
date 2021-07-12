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
        }

        public void Update()
        {
            //player does not contain playerHealthSystem attribute
            /*if (player.playerHealthSystem.GetHp() == 0)
        {
            turnManager.SetTrigger("PlayerToEnd");
        }*/
        }
    }
}
