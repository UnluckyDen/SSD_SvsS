using System;
using System.Collections;
using System.Collections.Generic;
using Manager;
using Players;
using UnityEngine;

public class NextTurn : MonoBehaviour
{
    private TurnController _turnController;
    private PlayerController _playerController;
    [SerializeField] private Player _player;


    private void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _turnController = FindObjectOfType<TurnController>();
    }

    private void OnMouseDown()
    {
        if (_playerController.CurrentPlayer == _player)
            _turnController.EndTurn();
    }
}