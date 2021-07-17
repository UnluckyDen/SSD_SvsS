using System;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Players.Deck
{
    public class DeckView : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUGUI;

        private void Start()
        {
            _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }
    }
}
