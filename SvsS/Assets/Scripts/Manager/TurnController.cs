using Players;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace Manager
{
    public class TurnController : MonoBehaviour
    {
        public Animator turnManager;
        [FormerlySerializedAs("PlayerController")][SerializeField] private PlayerController _playerController;
        private static readonly int PlayerFirst = Animator.StringToHash("PlayerFirst");
        private static readonly int EnemyFirst = Animator.StringToHash("EnemyFirst");
        private static readonly int PlayerToEnemy = Animator.StringToHash("PlayerToEnemy");
        private static readonly int EnemyToPlayer = Animator.StringToHash("EnemyToPlayer");
        private static readonly int PlayerToEnd = Animator.StringToHash("PlayerToEnd");
        private static readonly int EnemyToEnd = Animator.StringToHash("EnemyToEnd");

        public delegate void TurnChanged();

        public event TurnChanged OnTurnChanged;

        public void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
            turnManager.SetTrigger(_playerController.FirstPlayerID == 0 ? PlayerFirst : EnemyFirst);

            foreach (var player in _playerController.Players)
            {
                player.HealthSystem.OnDied += HealthSystem_OnDied;
            }
        }
        private void HealthSystem_OnDied()
        {
            Debug.Log("OnDied event is happened");
            if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                turnManager.SetTrigger(EnemyToEnd);
                //Debug.Log("EnemyToEnd is Activated");
            }
            else if(turnManager.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn"))
            {
                turnManager.SetTrigger(PlayerToEnd);
                //Debug.Log("PlayerToEnd is Activated");
            }
        }
        public void EndTurn()
        {
            if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn"))
            {
                EndTurnCode(PlayerToEnemy);
                OnTurnChanged?.Invoke();
            }
            else if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                EndTurnCode(EnemyToPlayer);
            }
        }
        private void EndTurnCode(int triggerName)
        {
            turnManager.SetTrigger(triggerName);
            _playerController.CurrentPlayer.IsAbleToInteract = false;
            _playerController.SwitchActivePlayer();
        }
        public void OnDestroy()
        {
            foreach (var player in _playerController.Players)
            {
                player.HealthSystem.OnDied -= HealthSystem_OnDied;
            }
        }
        public int GetCurrentState()
        {
            return turnManager.GetCurrentAnimatorStateInfo(0).fullPathHash;
        }

    }
   
}
