using System;
using UnityEngine;

namespace Systems
{
    public class PigPlaySound : MonoBehaviour
    {
        private AudioSource _audioSource;

        // Start is called before the first frame update
        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnMouseDown()
        {
            PlaySound();
        }

        public void PlaySound()
        {
            _audioSource.Play();
        }
    }
}