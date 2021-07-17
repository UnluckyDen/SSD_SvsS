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
    public class MechanicsControllerInt : MonoBehaviour
    {
        private List<Player> _players;
        private PlayerController _playerController;
        private PlayableZone _playableZone;
        private readonly List<IMechanic<int>> _mechanics = new List<IMechanic<int>>();

        private void Start()
        {
            _playableZone = GetComponentInChildren<PlayableZone>();
            _playableZone.CardIsPlayed += ApplyMessage;
            _playerController = FindObjectOfType<PlayerController>();
            _players = _playerController.Players;
        }

        private void ApplyMechanics([NotNull] List<IMechanic<int>> mechanics)
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
            foreach (var addDamage in message.addDamages)
            {
                _mechanics.Add(addDamage);
            }
            foreach (var addHeal in message.addHeals)
            {
                _mechanics.Add(addHeal);
            }
            foreach (var changeMana in message.changeMana)
            {
                _mechanics.Add(changeMana);
            }
            foreach (var dropCard in message.dropCards)
            {
                _mechanics.Add(dropCard);
            }
            foreach (var drawCard in message.drawCards)
            {
                _mechanics.Add(drawCard);
            }
            ApplyMechanics(_mechanics);
        }

        private void OnDestroy()
        {
            _playableZone.CardIsPlayed -= ApplyMessage;
        }
    }
}