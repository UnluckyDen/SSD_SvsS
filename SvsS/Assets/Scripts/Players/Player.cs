using System;
using Systems;
using UI;
using UnityEngine;

namespace Players
{
    public class Player : MonoBehaviour
    {
        public bool IsPlayer;
        public bool IsAbleToInteract = false;
        public PlayerSettingsData PlayerSettings;
        
        [NonSerialized] public HealthSystem HealthSystem;
        [NonSerialized] public ManaSystem ManaSystem;

        private int _hp;

        private GameObject _healthBar;
        public HealthBar HpBar;

        public int ManaToGive = 0;
        public Hand.Hand Hand;
        public Deck.Deck Deck;

        private void Awake()
        {
            HealthSystem = GetComponent<HealthSystem>();
            ManaSystem = GetComponentInChildren<ManaSystem>();
            CreateHpBar();
            CreateManaView();
        }

        private void CreateHpBar()
        {
            var hpBar = Instantiate(PlayerSettings.hpBar, 
                new Vector3(transform.position.x, 2f), Quaternion.identity);
            hpBar.transform.SetParent(transform);
        }

        private void CreateManaView()
        {
            var manaView = Instantiate(PlayerSettings.ManaView,
                new Vector3(gameObject.transform.position.x, 3f), Quaternion.identity);
            manaView.transform.SetParent(transform);
        }
    }
}