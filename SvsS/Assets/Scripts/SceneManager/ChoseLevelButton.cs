using UnityEngine;

namespace SceneManager
{
    public class ChoseLevelButton : MonoBehaviour
    {
        private LevelManager _levelManager;
        private void Start()
        {
            _levelManager = FindObjectOfType<LevelManager>();
        }

        public void ChoseLevel(int levelIndex)
        {
            _levelManager.LoadLevel(levelIndex);
        }
    }
}
