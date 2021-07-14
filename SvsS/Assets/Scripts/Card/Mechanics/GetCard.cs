using System;
using Systems;
using Card.Data;
using Interfaces;
using Players;
using UnityEngine;

namespace Card.Mechanics
{
    [System.Serializable]
    public class GetCard : IMechanic<CardData>

    {
        [SerializeField] private CardData _value;

        public void DoMechanic(CardData value, Player player)
        {
            CardCreator.CreateCard(value);
            //добавить в руку игрока
        }

        public CardData GetValue()
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