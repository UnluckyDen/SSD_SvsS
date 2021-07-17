using Players;
using System;
using UnityEngine;

namespace Systems
{
    public class HealthSystem : MonoBehaviour
    {
        public delegate void HealChanged(float hpPercent);
        public event HealChanged OnHealthChanged;
        public delegate void DeathCallback();
        public event DeathCallback OnDied;

        private Player _player;

        private int Hp { get; set; }

        private int _hpMax;
        
        private void Awake()
        {
            _player = GetComponentInParent<Player>();
            _hpMax = _player.PlayerSettings.hp;
            Hp = _hpMax;
        }

        public int GetHp()
        {
            return Hp;
        }

        public float GetHpPercent()
        {
            return (float) Hp / _hpMax;
        }

        public void ApplyDamage(int dmgAmount)
        {
            Hp -= dmgAmount;
            if (Hp < 0)
            {
                Hp = 0;               
            }
            if (Hp == 0)
            {
                OnDied?.Invoke();
            }
            OnHealthChanged?.Invoke(GetHpPercent());
        }

        public void ApplyHeal(int healAmount)
        {
            Hp += healAmount;
            if (Hp > _hpMax) Hp = _hpMax;
            OnHealthChanged?.Invoke(GetHpPercent());
        }
    }
}