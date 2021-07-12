using UnityEngine;
using Players.Data;
using System.Collections.Generic;
using Card.Data;

namespace Players
{
    public class Player : MonoBehaviour
    {
        public PlayerSettingsData playerSettings;

        public HealthSystem healthSystem;
        private int hp;
        private GameObject healthBar;
        public HealthBar hpBar;
        //public Animator animator;
        void Start()
        {          
            hp = playerSettings.hp;
            healthSystem = new HealthSystem(hp);
            healthBar = Instantiate(playerSettings.hpBar, new Vector3(0, 3), Quaternion.identity);
            hpBar = healthBar.GetComponent<HealthBar>();
            hpBar.Setup(healthSystem);
        }

        void Update()
        {
            if (healthSystem.GetHp() == 0)
            {
                Debug.Log("Player died");
                Destroy(gameObject);
                //string winstring = gameObject.ToString() + "ToEnd";
                //animator.SetTrigger(winstring);
            }
        }
    }
}
