using Players;
using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using static Systems.HealthSystem;

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

        public delegate void TurnChanged(bool isPlayer1Turn);

        public event TurnChanged OnTurnChanged;

        private IEnumerator _coroutine;

        public GameObject _winPanel;
        public GameObject _losePanel;

        public void Start()
        {
            _playerController = FindObjectOfType<PlayerController>();
            turnManager.SetTrigger(_playerController.FirstPlayerID == 0 ? PlayerFirst : EnemyFirst);

            foreach (var player in _playerController.Players)
            {
                player.HealthSystem.OnDied += HealthSystem_OnDied;
            }
        }
        private void HealthSystem_OnDied(Player player)
        {
            Debug.Log("OnDied event is happened" + player.name);
            if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                turnManager.SetTrigger(EnemyToEnd);
                _coroutine = SceneFinal(2, player);
                StartCoroutine(_coroutine);
                OnTurnChanged?.Invoke(true);
                //Debug.Log("EnemyToEnd is Activated");
            }
            else if(turnManager.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn"))
            {
                OnTurnChanged?.Invoke(true);
                turnManager.SetTrigger(PlayerToEnd);
                _coroutine = SceneFinal(2, player);
                StartCoroutine(_coroutine);
            }            
        }
        private IEnumerator SceneFinal(int time, Player player)
        {
            while (true)
            {
                yield return new WaitForSeconds(time);
                if (turnManager.GetCurrentAnimatorStateInfo(0).IsTag("End"))
                {
                    if (player.IsPlayer)
                    {
                        _playerController.gameObject.SetActive(false);
                        _losePanel.SetActive(true);                        
                    }
                    else
                    {
                        _playerController.gameObject.SetActive(false);
                        _winPanel.SetActive(true);
                    }
                }
                
            }
        }
        public void EndTurn()
        {

            if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("PlayerTurn"))
            {
                EndTurnCode(PlayerToEnemy);
                OnTurnChanged?.Invoke(false);
            }
            else if (turnManager.GetCurrentAnimatorStateInfo(0).IsName("EnemyTurn"))
            {
                EndTurnCode(EnemyToPlayer);
                OnTurnChanged?.Invoke(true);
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
