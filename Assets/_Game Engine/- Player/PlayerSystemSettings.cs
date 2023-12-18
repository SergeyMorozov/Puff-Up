using UnityEngine;

namespace GAME
{
    public class PlayerSystemSettings : ScriptableObject
    {
        public string StoreName;
        public bool ClearSavedData;

        [Header("Default")]
        public float Money;
        public float Crystal;
    }
}
