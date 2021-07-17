using Players;
using UnityEngine;

namespace Systems
{
    public class GameHandler : MonoBehaviour
    {
        public Player playerController;
        private HealthSystem _healthSystem;
        void Start()
        {
            _healthSystem = playerController.HealthSystem;
            Debug.Log("Health = " + _healthSystem.GetHp());
        }
        public void BtnDamage(int amount)
        {
            _healthSystem.ApplyDamage(amount);
            Debug.Log("Health = " + _healthSystem.GetHp()); 
        }
        public void BtnHeal(int amount)
        {
            _healthSystem.ApplyHeal(amount);
            Debug.Log("Health = " + _healthSystem.GetHp());
        }

    }
}
