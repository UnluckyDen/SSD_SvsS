using System.Collections.Generic;
using Card;
using Card.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class CardCreator : MonoBehaviour
    {
        public static void CreateCard(CardData cardData)
        {
            var cardGAmeObject =
                Instantiate(cardData.cardPrefab, new Vector3(0f, 0f, 0f), Quaternion.Euler(-90f, 0f, 0f));
            cardGAmeObject.GetComponentInChildren<Image>().sprite = cardData.sprite;

            TextMeshProUGUI[] texts = cardGAmeObject.GetComponentsInChildren<TextMeshProUGUI>();

            texts[0].text = cardData.name;
            texts[1].text = cardData.description;
            texts[2].text = (cardData.manaCost).ToString();

            cardGAmeObject.AddComponent<CardInfo>().Data = cardData;
        }
    }
}