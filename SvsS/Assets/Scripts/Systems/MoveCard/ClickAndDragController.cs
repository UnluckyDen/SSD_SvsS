using System;
using Card;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.iOS;

namespace Systems.MoveCard
{
    public class ClickAndDragController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        private float _upDistance;

        private Camera _camera;

        private GameObject _clickedCGameObject;

        public delegate void ElementCondition(GameObject message);

        public delegate void DragCondition(GameObject message1, Vector3 message2);

        public event DragCondition ElementClick;
        public event DragCondition ElementDrag;
        public event ElementCondition ElementRelease;

        private void Start()
        {
            _camera = Camera.main;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            var ray = _camera.ScreenPointToRay(eventData.position);
            Debug.DrawRay(_camera.transform.position, ray.direction, Color.red);
            if (!Physics.Raycast(_camera.transform.position, ray.direction, out var hit)) return;
            _clickedCGameObject = hit.collider.gameObject;
            _upDistance = hit.point.z;
            ElementClick?.Invoke(_clickedCGameObject, new Vector3(hit.point.x, hit.point.y, _upDistance));
        }

        public void OnDrag(PointerEventData eventData)
        {
            var ray = _camera.ScreenPointToRay(eventData.position);
            Debug.DrawRay(_camera.transform.position, ray.direction, Color.red);
            if (Physics.Raycast(_camera.transform.position, ray.direction, out var hit))
            {
                ElementDrag?.Invoke(_clickedCGameObject
                    
                    , new Vector3(hit.point.x, hit.point.y, _upDistance));
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ElementRelease?.Invoke(_clickedCGameObject);
            _clickedCGameObject = null;
        }
    }
}