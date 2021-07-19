using UnityEngine;

namespace Players
{
    public class AnimatorController : MonoBehaviour
    {
        private Animator _animator;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        public void SetAnimationPlayCard()
        {
            _animator.SetTrigger("PlayCard");
        }
    }
}
