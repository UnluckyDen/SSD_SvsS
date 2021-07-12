using Interfaces;
using Players;
using UnityEngine;

namespace Card.Mechanics
{
    [System.Serializable]
    class AddDamage : MonoBehaviour, IMechanic<int>

    {
        [SerializeField] private int _value;

        public void DoMechanic(int value, Player player)
        {
            player.HealthSystem.Damage(value);
        }

        public int GetValue()
        {
            return _value;
        }
    }
}
