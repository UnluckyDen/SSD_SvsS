using System;
using Interfaces;
using Players;
using UnityEngine;

namespace Card.Mechanics
{
    [System.Serializable]
    public class TestMechanic : IMechanic<String>
    {
        [SerializeField] private string _value;

        public void DoMechanic(string mechanic, Player player)
        {
            Debug.Log(mechanic + " " + target);
        }

        public string GetValue()
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