using System.Collections.Generic;
using Card.Mechanics;
using UnityEngine;

namespace Card.Data
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Card Data", order = 0)]
    public class CardData : ScriptableObject
    {
        [Header("Card appearance")] public new string name;
        public string description;
        public int manaCost;
        public Sprite sprite;
        public GameObject cardPrefab;

        [Header("Card mechanics")] public List<AddDamage> addDamages;
        public List<AddHeal> addHeals;
        public List<ChangeMana> changeMana;
        public List<DrawCard> drawCards;
        public List<DropCard> dropCards;
        public List<GetCard> getCards;


        public List<TestMechanic> testsMechanics;
    }
}