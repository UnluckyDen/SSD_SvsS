using System;
using Card.Data;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Players.Deck
{
    public class DeckView : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshProUGUI;
        private Deck _deck;

        private void Start()
        {
            _textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
            _deck = GetComponentInParent<Deck>();
            _textMeshProUGUI.text = _deck.CardCount.ToString();
            _deck.CardCountChanged += ShowCurrentCardCount;
        }

        private void ShowCurrentCardCount()
        {
            _textMeshProUGUI.text = _deck.CardCount.ToString();
        }

        private void OnDestroy()
        {
            _deck.CardCountChanged -= ShowCurrentCardCount;
        }
    }
}
