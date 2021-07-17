using System;
using Interfaces;
using Players;
using UnityEngine;

namespace Card.Mechanics
{
    [System.Serializable]
    public class ChangeMana : IMechanic<int>

    { 
        private int _value;
        [SerializeField] private int _addMana;
        [SerializeField] private int _subtractMana;
        public void DoMechanic(int value, Player player)
        {
            player.ManaSystem.AddMana(_addMana);
            player.ManaSystem.SubtractMana(_subtractMana);
        }

        public int GetValue()
        {
            return _value;
        }

        public enum WhoIsTarget
        {
            CurrentPlayer,
            Enemy
        };

        [SerializeField] private WhoIsTarget target = WhoIsTarget.CurrentPlayer;

        public int GetTarget()
        {
            return target switch
            {
                WhoIsTarget.CurrentPlayer => 0,
                WhoIsTarget.Enemy => 1,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}