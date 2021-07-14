using System;
using System.Collections.Generic;
using Card.Data;
using Interfaces;
using JetBrains.Annotations;
using Players;
using UnityEngine;

namespace Systems.MechanicsSystems
{
    public class MechanicsControllerString : MonoBehaviour
    {
        public List<Player> players;
        private PlayableZone _playableZone;
        private readonly List<IMechanic<String>> _mechanics = new List<IMechanic<String>>();

        private void Start()
        {
            //найти на сцене,пишу в 4.30 поэтому мне лень
            _playableZone = GetComponentInChildren<PlayableZone>();
            _playableZone.CardIsPlayed += DisplayMessage;
            //это тест игроков надо по умному сюда добавлять из плейр контроллера и каждый раз свапать
            players.Add(new Player());
            players.Add(new Player());
        }

        private void ApplyMechanics([NotNull] List<IMechanic<String>> mechanics)
        {
            if (mechanics == null) throw new ArgumentNullException(nameof(mechanics));

            foreach (var mechanic in mechanics)
            {
                mechanic.DoMechanic(mechanic.GetValue(), players[mechanic.GetTarget()]);
            }
            _mechanics.Clear();
        }
        
        private void DisplayMessage(CardData message)
        {
            foreach (var testMechanic in message.testsMechanics)
            {
                _mechanics.Add(testMechanic);
            }
            ApplyMechanics(_mechanics);
        }

        private void OnDestroy()
        {
            _playableZone.CardIsPlayed -= DisplayMessage;
        }
    }
}
