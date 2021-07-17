using UnityEngine;

namespace Players
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 1)]
    public class PlayerSettingsData : ScriptableObject
    {
        public int hp;
        public GameObject hpBar;
        
        [Space]
        
        public int StartMana;
        public int MaxMana;

        public GameObject ManaView;
        
        [Space]
        
        public GameObject playerModel;
    }
}
