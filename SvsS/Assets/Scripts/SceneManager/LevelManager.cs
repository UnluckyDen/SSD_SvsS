using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneManager
{
    public class LevelManager : MonoBehaviour
    {
        private void Awake()
        {
            if (FindObjectsOfType<LevelManager>().Length > 1)
                Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public void LoadLevel(int levelIndex)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex: levelIndex);
        }
    }
}