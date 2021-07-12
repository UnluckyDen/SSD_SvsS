﻿using Interfaces;
using Players;

namespace Card.Mechanics
{
    class AddDamage : IMechanic
    {
        public void DoMechanic(int value, Player player)
        {
            player.healthSystem.Damage(value);
        }
    }
}
