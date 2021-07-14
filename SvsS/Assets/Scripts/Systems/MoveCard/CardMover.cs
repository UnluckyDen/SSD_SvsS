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
            _inputController.CardRelease += CardPlay;
        }

        void Update()
        {
            MoveCard();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        void MoveCard()
        {
            if (_inputController.ClickObject == null) return;
            if (_inputController.ClickObject.GetComponent<CardHandler>() != null)
            {
                _inputController.ClickObject.transform.position = _inputController.InputPosition;
            }
        }

        void ResetCardPosition()
        {
            //возвращает карту в руку
            Debug.Log("Pasasi ne raz ne realizoval");
        }

        private void CardPlay()
        {
            var ray = new Ray {origin = _inputController.ClickObject.transform.position, direction = Vector3.forward};
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            if (!Physics.Raycast(ray.origin, ray.direction, out var hit)) return;
            if (hit.collider.gameObject.GetComponentInParent<PlayableZone>() != null)
            {
                _inputController.ClickObject.transform.position = hit.collider.gameObject.GetComponentInParent<PlayableZone>()
                    .transform.position;
                _inputController.ClickObject.transform.SetParent(hit.collider.gameObject.GetComponentInParent<PlayableZone>().transform);
            }
            else
            {
                ResetCardPosition();
            }
        }

        private void OnDestroy()
        {
            _inputController.CardRelease -= CardPlay;
        }
    }
}