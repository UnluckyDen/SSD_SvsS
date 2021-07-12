using System;
using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Card.Mechanics;
using JetBrains.Annotations;

namespace Players
{
    class PlayerController : MonoBehaviour
    {
        public List<Player> players;
        Player _currentPlayer;
        private void Start()
        {
          
        }
        private void ApplyEffects([NotNull] IMechanic mechanic)
        {
            if (mechanic == null) throw new ArgumentNullException(nameof(mechanic));
            mechanic = new AddDamage();
            mechanic.DoMechanic(10, _currentPlayer);
        }
    }
}
/*
 * у нас будет событие, которым мы подпишемся на выход карты. генератор событий будет на столе.
 * получив данные карты, мы будем вызывать метод DoMechanic со значениями, которые внутри карты.
 */