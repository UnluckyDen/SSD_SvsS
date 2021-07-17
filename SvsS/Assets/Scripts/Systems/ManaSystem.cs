using System;
using Players;
using UnityEngine;

namespace Systems
{
    public class ManaSystem : MonoBehaviour
    {
        public delegate void ChangeManaEvent(int message1, int message2);

        public event ChangeManaEvent CurrentManaChanged;

        public int CurrentMana => _currentMana;
        public int MAXMana => _maxMana;

        private int _maxMana;
        private int _startMana;
        private int _currentMana;

        private Player _player;

        private void Awake()
        {
            _player = GetComponentInParent<Player>();
            _maxMana = _player.PlayerSettings.MaxMana;
            _startMana = _player.PlayerSettings.StartMana;
        }
        private void Start()
        {
            _currentMana = _startMana;            
        }

        public void AddMana(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value) + ":" + value + " can`t be negativ");
            _currentMana += value;
            if (_currentMana > _maxMana) _currentMana = _maxMana;
            CurrentManaChanged?.Invoke(_currentMana, _maxMana);
        }

        public void SubtractMana(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value) + ":" + value + " can`t be negativ");
            _currentMana -= value;
            if (_currentMana < 0) _currentMana = 0;
            CurrentManaChanged?.Invoke(_currentMana, _maxMana);
        }

        public void SetMana(int value)
        {
            if (value > _maxMana || value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value) + ":" + value + " must be in range " + 0 + ".." +
                                                      _maxMana);
            }

            _currentMana = value;
            CurrentManaChanged?.Invoke(_currentMana, _maxMana);
        }
    }
}