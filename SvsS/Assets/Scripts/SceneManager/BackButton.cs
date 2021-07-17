using System;
using UnityEngine;

namespace SceneManager
{
    public class BackButton : MonoBehaviour
    {
        private LevelManager _levelManager;
        private void Start()
        {
            _levelManager = FindObjectOfType<LevelManager>();
        }

        public void BackToMenu()
        {
            _levelManager.LoadLevel(0);
        }
    }
}
