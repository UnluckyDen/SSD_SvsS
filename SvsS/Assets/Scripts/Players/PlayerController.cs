using System.Collections.Generic;
using UnityEngine;

namespace Players
{
    class PlayerController : MonoBehaviour
    {
        public List<Player> Players;

        public Player CurrentPlayer => Players[0];

        public void SwitchActivePlayer()
        {
            var firstPlayer = Players[0];
            for (var i = 0; i < Players.Count - 1; i++)
            {
                Players[i] = Players[i + 1];
            }

            Players[Players.Count - 1] = firstPlayer;
        }
    }
}