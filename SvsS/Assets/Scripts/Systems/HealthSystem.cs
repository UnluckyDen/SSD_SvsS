using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    public event EventHandler OnDied;
    private int hp;
    private int hpMax;

    public HealthSystem(int hpmax)
    {
        this.hpMax = hpmax;
        hp = hpmax;
    }
    public int GetHp()
    {
        return hp;
    }
    public float GetHpPercent()
    {
        return (float)hp / hpMax;
    }
    public void Damage(int dmgAmount)
    {
        hp -= dmgAmount;
        if (hp < 0) hp = 0;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        if (hp == 0) OnDied(this, EventArgs.Empty);
    }
    public void Heal(int healAmount)
    {
        hp += healAmount;
        if (hp > hpMax) hp = hpMax;
        if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
    }
}
