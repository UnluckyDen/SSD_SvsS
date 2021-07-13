using System;

namespace Systems
{
    public class HealthSystem
    {
        public event EventHandler OnHealthChanged;
        public event EventHandler OnDied;
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
            return (float)_hp / _hpMax;
        }
        public void Damage(int dmgAmount)
        {
            _hp -= dmgAmount;
            if (_hp < 0) _hp = 0;
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
