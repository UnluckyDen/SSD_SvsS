using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Players.Data
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/PlayerSettings", order = 1)]
    public class PlayerSettingsData : ScriptableObject
    {
        public int hp;
        public GameObject hpBar;
        public GameObject playerModel;
    }
}
