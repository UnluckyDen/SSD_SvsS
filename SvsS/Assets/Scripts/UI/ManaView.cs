using System;
using System.Collections;
using Systems;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ManaView : MonoBehaviour
    {
        private ManaSystem _manaSystem;

        private TextMeshProUGUI _textMeshProUGUI;

        private void Start()
        {
            _manaSystem = GetComponentInParent<ManaSystem>();
            _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            _manaSystem.CurrentManaChanged += UpdateCurrentManaView;
            UpdateCurrentManaView(_manaSystem.CurrentMana,_manaSystem.MAXMana);
        }

        private void UpdateCurrentManaView(int value,int value2)
        {
            _textMeshProUGUI.text = value + "/" + value2;
        }

        private void OnDestroy()
        {
            _manaSystem.CurrentManaChanged -= UpdateCurrentManaView;
        }
    }
}
