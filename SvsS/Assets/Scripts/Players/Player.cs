using System;
using Systems;
using UI;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        public PlayerSettingsData PlayerSettings;
        public HealthSystem HealthSystem;
        
        [NonSerialized] public ManaSystem ManaSystem;
        
        private int _hp;

        private GameObject _healthBar;
        public HealthBar HpBar;

        public Hand.Hand Hand;
        public Deck.Deck Deck;

        private void Start()
        {
            ManaSystem = GetComponentInChildren<ManaSystem>();
            CreateHpBar();
            CreateManaView();
        }

        private void Update()
        {
            if (HealthSystem.GetHp() != 0) return;
            //В хп систему событие запихни, которое инвоукится при 0 хп
            Debug.Log("Player died");
            Destroy(gameObject);
        }

        private void CreateHpBar()
        {
            _hp = PlayerSettings.hp;
            HealthSystem = new HealthSystem(_hp);
            _healthBar = Instantiate(PlayerSettings.hpBar, new Vector3(gameObject.transform.position.x, 3),
                Quaternion.identity);
            _healthBar.transform.SetParent(transform);
            HpBar = _healthBar.GetComponent<HealthBar>();
            HpBar.Setup(HealthSystem);
        }

        private void CreateManaView()
        {
            var manaView = Instantiate(PlayerSettings.ManaView,
                new Vector3(gameObject.transform.position.x, 4f),Quaternion.identity);
            manaView.transform.SetParent(transform);
        }
    }
}