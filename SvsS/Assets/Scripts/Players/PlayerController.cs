using System;
using Interfaces;
using System.Collections.Generic;
using System.Reflection;
using Card.Data;
using UnityEngine;
using JetBrains.Annotations;

namespace Players
{
    class PlayerController<T> : MonoBehaviour //из-за "T юнити считает, что это не монобех скрипт,".С каждой секундой я всё больше и больше жалею, что мы не юзам LEOEcs
    {
        public List<Player> players;
        private readonly List<IMechanic<T>> _mechanics = new List<IMechanic<T>>();
        public CardData _cardData;

        private void Start()
        {
            //_mechanics.Add(mechanic  = (IMechanic<T>) _cardData._cardMechanicsList);
            //_mechanics.Add((IMechanic<T>) _cardData.addDamages[0]);
            foreach (var testMechanic in _cardData.testsMechanics)
            {
                _mechanics.Add((IMechanic<T>) testMechanic);
            }
            foreach (var damage in _cardData.addDamages)
            {
                _mechanics.Add((IMechanic<T>) damage);
            }

            ApplyMechanics(_mechanics);
        }

        private void ApplyMechanics([NotNull] List<IMechanic<T>> mechanics)
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