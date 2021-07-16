using Card;
using UnityEngine;

namespace Players.Hand
{
    public class HandCardHolder : MonoBehaviour
    {
        private void Update()
        {
            if (gameObject.transform.childCount == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}