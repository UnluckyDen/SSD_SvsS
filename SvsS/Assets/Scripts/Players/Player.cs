using Systems;
using UI;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        public PlayerSettingsData playerSettings;
        public HealthSystem HealthSystem;
        private int _hp;
        private GameObject _healthBar;
        public HealthBar hpBar;
        void Start()
        {
            _hp = playerSettings.hp;
            HealthSystem = new HealthSystem(_hp);
            _healthBar = Instantiate(playerSettings.hpBar, new Vector3(this.transform.position.x, 3), Quaternion.identity);
            hpBar = _healthBar.GetComponent<HealthBar>();
            hpBar.Setup(HealthSystem);
        }

        void Update()
        {
            if (HealthSystem.GetHp() != 0) return;
            Debug.Log("Player died");
            Destroy(gameObject);
        }
    }
}