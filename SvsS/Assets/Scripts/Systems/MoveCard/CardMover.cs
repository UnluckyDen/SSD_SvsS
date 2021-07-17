using System;
using Card;
using Players;
using UnityEngine;

namespace Systems.MoveCard
{
    public class CardMover : MonoBehaviour
    {
        [SerializeField] private Player _ownerOfMoves;
        
        private ClickAndDragController _inputController;
        private PlayerController _playerController;


        void Start()
        {
            _inputController = (ClickAndDragController) FindObjectOfType(typeof(ClickAndDragController));
            _inputController.ElementClick += MoveCard;
            _inputController.ElementDrag += MoveCard;
            _inputController.ElementRelease += CardPlay;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        void MoveCard(GameObject card, Vector3 dragPosition)
        {
            if(card == null) return;
            if (card.GetComponent<CardInfo>() == null) return;
            card.transform.position = dragPosition;
            card.transform.SetParent(gameObject.transform);
        }

        void ResetCardPosition(GameObject card)
        {
            _ownerOfMoves.Hand.AddCardToHand(card.GetComponent<CardInfo>());
            card.transform.localPosition = Vector3.zero;
        }

        private void CardPlay(GameObject card)
        {
            if (card == null) return;
            var ray = new Ray {origin = card.transform.position, direction = Vector3.forward};
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit) &&
                hit.collider.gameObject.GetComponentInParent<PlayableZone>() != null)
            {
                card.transform.position =
                    hit.collider.gameObject.GetComponentInParent<PlayableZone>().transform.position;
                card.transform.SetParent(hit.collider.gameObject.GetComponentInParent<PlayableZone>().transform);
            }
            else
            {
                ResetCardPosition(card);
            }
        }

        private void OnDestroy()
        {
            _inputController.ElementClick -= MoveCard;
            _inputController.ElementDrag -= MoveCard;
            _inputController.ElementRelease -= CardPlay;
        }
    }
}