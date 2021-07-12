using System;
using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Card.Mechanics;
using JetBrains.Annotations;

namespace Players
{
    class PlayerController<T> : MonoBehaviour

    {
        public List<Player> players;
        Player _currentPlayer;
        private readonly List<IMechanic<T>> _mechanics = new List<IMechanic<T>>();

        private void Start()
        {
            _mechanics.Add((IMechanic<T>) new AddDamage());
            _mechanics.Add((IMechanic<T>) new AddHeal());

        }

        private void ApplyEffects([NotNull] List<IMechanic<T>> mechanics, Player targetPlayer)
        {
            if (mechanics == null) throw new ArgumentNullException(nameof(mechanics));

            foreach (var mechanic in mechanics)
            {
                mechanic.DoMechanic(mechanic.GetValue(), targetPlayer);
            }
            /*
 * у нас будет событие, которым мы подпишемся на выход карты. генератор событий будет на столе.
 * получив данные карты, мы будем вызывать метод DoMechanic со значениями, которые внутри карты.
 */
        }
    }
}
