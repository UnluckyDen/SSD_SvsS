using System;
using System.Collections.Generic;
using System.Linq;
using Card.Data;
using Interfaces;
using JetBrains.Annotations;
using Players;
using UnityEngine;

namespace Systems.MechanicsSystems
{
    public class MechanicsControllerCard : MonoBehaviour
    {
        private List<Player> _players;
        private PlayerController _playerController;
        private PlayableZone _playableZone;
        private readonly List<IMechanic<CardData>> _mechanics = new List<IMechanic<CardData>>();

        private void Start()
        {
            _playableZone = GetComponentInChildren<PlayableZone>();
            _playableZone.CardIsPlayed += ApplyMessage;
            _playerController = FindObjectOfType<PlayerController>();
            _players = _playerController.Players;
        }

        private void ApplyMechanics([NotNull] List<IMechanic<CardData>> mechanics)
        {
            if (mechanics == null) throw new ArgumentNullException(nameof(mechanics));

            foreach (var mechanic in mechanics)
            {
                mechanic.DoMechanic(mechanic.GetValue(), _players[mechanic.GetTarget()]);
            }
            _mechanics.Clear();
        }
        
        private void ApplyMessage(CardData message)
        {
            foreach (var getCard in message.getCards)
            {
                _mechanics.Add(getCard);
            }
            ApplyMechanics(_mechanics);
        }

        private void OnDestroy()
        {
            _playableZone.CardIsPlayed -= ApplyMessage;
        }
    }
}