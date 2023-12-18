using UnityEngine;

namespace GAME
{
    public class PlayerPreset : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public PlayerRef Prefab;

        public float TimeAddEnergy;
    }
}

