using Systems;
using Card.Data;
using Interfaces;
using Players;
using UnityEngine;

namespace Card.Mechanics
{
    [System.Serializable]
    class GetCard : MonoBehaviour, IMechanic<CardData>

    {
    [SerializeField] private CardData _value;

    public void DoMechanic(CardData value, Player player)
    {
        CardCreator.CreateCard(value);
    }

    public CardData GetValue()
    {
        return _value;
    }
    }
}
