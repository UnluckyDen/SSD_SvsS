using System;
using System.Collections.Generic;
using Card.Data;
using Interfaces;
using JetBrains.Annotations;
using Players;
using UnityEngine;

namespace Systems.MechanicsSystems
{
    public class MechanicsControllerInt : MonoBehaviour
    {
        public List<Player> players;
        private readonly List<IMechanic<int>> _mechanics = new List<IMechanic<int>>();
        public CardData _cardData;

        private void Start()
        {
            //_mechanics.Add(mechanic  = (IMechanic<T>) _cardData._cardMechanicsList);
            //_mechanics.Add((IMechanic<T>) _cardData.addDamages[0]);
            foreach (var testMechanic in _cardData.testsMechanics)
            {
                _mechanics.Add(testMechanic as IMechanic<int>);
            }

            ApplyMechanics(_mechanics);
        }

        private void ApplyMechanics([NotNull] List<IMechanic<int>> mechanics)
        {
            if (mechanics == null) throw new ArgumentNullException(nameof(mechanics));

            foreach (var mechanic in mechanics)
            {
                mechanic.DoMechanic(mechanic.GetValue(), players[mechanic.GetTarget()]);
            }

            /*
 * у нас будет событие, которым мы подпишемся на выход карты. генератор событий будет на столе.
 * получив данные карты, мы будем вызывать метод DoMechanic со значениями, которые внутри карты.
 */
        }
    }
}
