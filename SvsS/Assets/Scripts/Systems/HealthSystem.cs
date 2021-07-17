using System;

namespace Systems
{
    public class HealthSystem
    {
        public event EventHandler OnHealthChanged;
        private int _hp;
        private readonly int _hpMax;

        public HealthSystem(int maxHp)
        {
            _hpMax = maxHp;
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
            if (_hp < 0) _hp = 0;
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ApplyHeal(int healAmount)
        {
            _hp += healAmount;
            if (_hp > _hpMax) _hp = _hpMax;
            OnHealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}