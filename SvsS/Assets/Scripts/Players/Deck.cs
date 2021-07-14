using Card.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Players
{
    public class Deck : MonoBehaviour
    {
        public readonly List<CardData> CardDatas;
        private List<CardData> ReservedCardDatas;
        private void Start()
        {
            ReservedCardDatas.AddRange(CardDatas.ToArray());
        }
    }
}
