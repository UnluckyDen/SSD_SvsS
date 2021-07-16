using Players;
using System;
using UnityEngine;

namespace Systems
{
    public class HealthSystem
    {
        public event EventHandler OnHealthChanged;

        public delegate void DeathCallback(Player player);
        public DeathCallback OnDied;

        private int _hp;
        private readonly int _hpMax;

        public HealthSystem(int maxHp)
        {
            this._hpMax = maxHp;
            _hp = maxHp;
        }

        public int GetHp()
        {
            return _hp;
        }

        public float GetHpPercent()
        {
            return (float) _hp / _hpMax;
        }

        public void ApplyDamage(int dmgAmount)
        {
            _hp -= dmgAmount;
            if (_hp < 0)
            {
                _hp = 0;               
            }
            if (_hp == 0)
            {
                Debug.Log("OnDied is invoked");
            }
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }

        public void Heal(int healAmount)
        {
            _hp += healAmount;
            if (_hp > _hpMax) _hp = _hpMax;
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}