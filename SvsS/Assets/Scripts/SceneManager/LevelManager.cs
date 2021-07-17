using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManager
{
    public class LevelManager : MonoBehaviour
    {
        private void Start()
        {
            LevelManager.DontDestroyOnLoad(gameObject);
            
        }

        public void LoadLevel(int levelIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
