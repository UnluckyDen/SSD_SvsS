using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;
    private Transform bar;
    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        bar = transform.Find("Bar");
        healthSystem.OnHealthChanged += HealthSystemOnHealthChanged;
    }
    private void HealthSystemOnHealthChanged(object sender, System.EventArgs e)
    {
        bar.localScale = new Vector3(healthSystem.GetHpPercent(), 1);
    }
}
