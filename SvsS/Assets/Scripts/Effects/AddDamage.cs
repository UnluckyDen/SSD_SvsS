using Assets.Scripts.Interfaces;
using Unity;
using UnityEngine;
using Players;

namespace Assets.Scripts.Effects
{
    class AddDamage : IEffects
    {
        public void DoMechanic(int value, Player player)
        {
            player.healthSystem.Damage(value);
        }
    }
}
