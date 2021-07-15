using Card;
using UnityEngine;

namespace Players.Hand
{
    public class HandCardHolder : MonoBehaviour
    {
        public CardInfo _cardInfo;

        // Start is called before the first frame update
        private void Start()
        {
            if (gameObject.GetComponentInChildren<CardInfo>() != null)
                _cardInfo = gameObject.GetComponentInChildren<CardInfo>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (_cardInfo == null)
            {
                Destroy(gameObject);
            }
        }
    }
}