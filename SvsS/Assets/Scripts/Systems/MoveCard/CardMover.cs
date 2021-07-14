using System;
using Card;
using UnityEngine;

namespace Systems.MoveCard
{
    public class CardMover : MonoBehaviour
    {
        private ClickAndDragController _inputController;


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
            if (card.GetComponent<CardHandler>() != null)
            {
                card.transform.position = dragPosition;
            }
        }

        void ResetCardPosition()
        {
            //возвращает карту в руку
            Debug.Log("Pasasi raz ne realizoval");
        }

        private void CardPlay(GameObject card)
        {
            if (card == null) return;
            var ray = new Ray {origin = card.transform.position, direction = Vector3.forward};
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            if (!Physics.Raycast(ray.origin, ray.direction, out var hit)) return;
            if (hit.collider.gameObject.GetComponentInParent<PlayableZone>() != null)
            {
                card.transform.position =
                    hit.collider.gameObject.GetComponentInParent<PlayableZone>().transform.position;
                card.transform.SetParent(hit.collider.gameObject.GetComponentInParent<PlayableZone>().transform);
            }
            else
            {
                ResetCardPosition();
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