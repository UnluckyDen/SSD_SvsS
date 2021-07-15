using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.iOS;

namespace Systems.MoveCard
{
    public class ClickAndDragController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public float upDistance;

        private GameObject _clickedCGameObject;

        public delegate void ElementCondition(GameObject message);

        public delegate void DragCondition(GameObject message1, Vector3 message2);

        public event DragCondition ElementClick;
        public event DragCondition ElementDrag;
        public event ElementCondition ElementRelease;

        public void OnPointerDown(PointerEventData eventData)
        {
            var ray = Camera.main.ScreenPointToRay(eventData.position);
            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red);
            if (!Physics.Raycast(Camera.main.transform.position, ray.direction, out var hit)) return;
            _clickedCGameObject = hit.collider.gameObject;
            ElementClick?.Invoke(_clickedCGameObject, new Vector3(hit.point.x, hit.point.y, -upDistance));
        }

        public void OnDrag(PointerEventData eventData)
        {
            var ray = Camera.main.ScreenPointToRay(eventData.position);
            Debug.DrawRay(Camera.main.transform.position, ray.direction, Color.red);
            if (Physics.Raycast(Camera.main.transform.position, ray.direction, out var hit))
            {
                ElementDrag?.Invoke(_clickedCGameObject
                    
                    , new Vector3(hit.point.x, hit.point.y, -upDistance));
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ElementRelease?.Invoke(_clickedCGameObject);
            _clickedCGameObject = null;
        }
    }
}