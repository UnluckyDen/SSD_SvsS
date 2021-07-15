using Systems;
using UI;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        public PlayerSettingsData PlayerSettings;
        public HealthSystem HealthSystem;
        private int _hp;
        private GameObject _healthBar;
        public HealthBar HpBar;
        public Hand.Hand Hand;
        public Deck.Deck Deck;
        void Start()
        {
            _hp = PlayerSettings.hp;
            HealthSystem = new HealthSystem(_hp);
            _healthBar = Instantiate(PlayerSettings.hpBar, new Vector3(gameObject.transform.position.x, 3), Quaternion.identity);
            HpBar = _healthBar.GetComponent<HealthBar>();
            HpBar.Setup(HealthSystem);
        }

        void Update()
        {
            if (HealthSystem.GetHp() != 0) return;
            Debug.Log("Player died");
            Destroy(gameObject);
        }
    }
}
