using Assets.Scripts.Effects;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Players
{
    class PlayerController : MonoBehaviour
    {
        public List<Player> players;
        Player currentPlayer;
        private void Start()
        {
          
        }
        private void ApplyEffects(IEffects effect)
        {
            effect = new AddDamage();
            effect.DoMechanic(10, currentPlayer);
        }
    }
}
/*
 * у нас будет событие, которым мы подпишемся на выход карты. генератор событий будет на столе.
 * получив данные карты, мы будем вызывать метод DoMechanic со значениями, которые внутри карты.
 */