using System;
using Interfaces;
using Players;
using UnityEngine;

namespace Card.Mechanics
{
    [System.Serializable]
    public class AddHeal : IMechanic<int>

    {
        [SerializeField] private int _value;

        public void DoMechanic(int value, Player player)
        {
            player.HealthSystem.Heal(value);
        }

        public int GetValue()
        {
            return _value;
        }

        public enum WhoIsTarget
        {
            CurrentPlayer ,
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