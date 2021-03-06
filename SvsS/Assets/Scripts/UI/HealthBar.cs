using System;
using Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        private HealthSystem _healthSystem;
        [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
        [SerializeField] private Image _bar;

        private void Start()
        {
            _healthSystem = GetComponentInParent<HealthSystem>();
            _healthSystem.OnHealthChanged += HealthSystemOnHealthChanged;
        }

        private void HealthSystemOnHealthChanged(float hpPercent)
        {
            _bar.fillAmount = _healthSystem.GetHpPercent();
            _textMeshProUGUI.text = (hpPercent * 100).ToString();
        }

        private void OnDestroy()
        {
            _healthSystem.OnHealthChanged -= HealthSystemOnHealthChanged;
        }
    }
}