using System;
using Card;
using Players;
using UnityEngine;

namespace Systems.MoveCard
{
    public class CardMover : MonoBehaviour
    {
        private ClickAndDragController _inputController;

        private PlayerController _playerController;

        void Start()
        {
            _playerController = gameObject.GetComponent<PlayerController>();
            _inputController = (ClickAndDragController) FindObjectOfType(typeof(ClickAndDragController));
            _inputController.ElementClick += MoveCard;
            _inputController.ElementDrag += MoveCard;
            _inputController.ElementRelease += CardPlay;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        void MoveCard(GameObject card, Vector3 dragPosition)
        {
            if(card == null) return;
            if (card.GetComponent<CardInfo>() != null)
            {
                card.transform.position = dragPosition; //new Vector3(dragPosition.x, dragPosition.y, 0f);
               // card.transform.localPosition.z = dragPosition.z;              
            }
        }

        void ResetCardPosition(GameObject card)
        {
            card.transform.localPosition = Vector3.zero;
        }

        private void CardPlay(GameObject card)
        {
            if (card == null) return;
            var ray = new Ray {origin = card.transform.position, direction = Vector3.forward};
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            if (Physics.Raycast(ray.origin, ray.direction, out var hit) &&
                hit.collider.gameObject.GetComponentInParent<PlayableZone>() != null &&
                _playerController.CurrentPlayer.IsPlayer && _playerController.CurrentPlayer.IsAbleToInteract)
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