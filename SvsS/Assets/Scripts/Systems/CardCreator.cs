using Card;
using Card.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class CardCreator : MonoBehaviour
    {
        public GameObject CreateCard(CardData cardData)
        {
            var cardGameObject =
                Instantiate(cardData.cardPrefab, gameObject.transform.position, Quaternion.Euler(-90f, 0f, 0f));
            cardGameObject.GetComponentInChildren<Image>().sprite = cardData.sprite;

            TextMeshProUGUI[] texts = cardGameObject.GetComponentsInChildren<TextMeshProUGUI>();

            texts[0].text = cardData.name;
            texts[1].text = cardData.description;
            texts[2].text = (cardData.manaCost).ToString();

            cardGameObject.GetComponent<CardInfo>().Data = cardData;

            return cardGameObject;
        }
    }
}