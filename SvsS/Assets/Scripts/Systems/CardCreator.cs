using System.Collections.Generic;
using Card.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Systems
{
    public class CardCreator : MonoBehaviour
    {

        public static void CreateCard(CardData card)
        {
            var cartGAmeObject = Instantiate(card.cardPrefab,new Vector3(0f,0f,0f),Quaternion.Euler(-90f,0f,0f));
            cartGAmeObject.GetComponentInChildren<Image>().sprite = card.sprite;
            
            TextMeshProUGUI[] texts = cartGAmeObject.GetComponentsInChildren<TextMeshProUGUI>();
            
            texts[0].text = card.name;
            texts[1].text = card.description;
            texts[2].text = (card.manaCost).ToString();
        }
    }
}
