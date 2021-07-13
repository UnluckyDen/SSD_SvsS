using Systems;
using UnityEngine;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        private HealthSystem _healthSystem;
        private Transform _bar;
        public void Setup(HealthSystem healthSystem)
        {
            this._healthSystem = healthSystem;
            _bar = transform.Find("Bar");
            healthSystem.OnHealthChanged += HealthSystemOnHealthChanged;
        }
        private void HealthSystemOnHealthChanged(object sender, System.EventArgs e)
        {
            _bar.localScale = new Vector3(_healthSystem.GetHpPercent(), 1);
        }
    }
}
