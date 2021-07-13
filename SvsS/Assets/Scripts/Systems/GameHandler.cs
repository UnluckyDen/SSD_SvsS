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
            _healthSystem = playerController.healthSystem;
            Debug.Log("Health = " + _healthSystem.GetHp());
        }
        public void BtnDamage(int amount)
        {
            _healthSystem.Damage(amount);
            Debug.Log("Health = " + _healthSystem.GetHp()); 
        }
        public void BtnHeal(int amount)
        {
            _healthSystem.Heal(amount);
            Debug.Log("Health = " + _healthSystem.GetHp());
        }

    }
}
