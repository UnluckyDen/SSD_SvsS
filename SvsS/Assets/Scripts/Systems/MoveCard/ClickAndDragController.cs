using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.iOS;
using UnityEngine.Serialization;

namespace Systems.MoveCard
{
    public class ClickAndDragController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public float upDistance;

        private GameObject _clickedCGameObject;
        private Vector3 _inputPosition;

        public delegate void CardCondition();

        public event CardCondition CardRelease;

        public void OnPointerDown(PointerEventData eventData)
        {
            var ray = Camera.main.ScreenPointToRay(eventData.position);
            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red);
            if (Physics.Raycast(Camera.main.transform.position, ray.direction, out var hit))
            {
                _inputPosition = new Vector3(hit.point.x, hit.point.y, -upDistance);
                _clickedCGameObject = hit.collider.gameObject;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            var ray = Camera.main.ScreenPointToRay(eventData.position);
            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red);
            if (Physics.Raycast(Camera.main.transform.position, ray.direction, out var hit))
            {
                _inputPosition = new Vector3(hit.point.x, hit.point.y, -upDistance);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            CardRelease?.Invoke();
            _clickedCGameObject = null;
        }

        public GameObject ClickObject => _clickedCGameObject;

        public Vector3 InputPosition => _inputPosition;
    }
}