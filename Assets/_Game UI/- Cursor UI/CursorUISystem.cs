using UnityEngine;

namespace GAME
{
    public class CursorUISystem : MonoBehaviour
    {
        private static CursorUISystem _instance;

        public static CursorUISystem Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<CursorUISystem>();
                return _instance;
            }
        }

        // Views
        public CursorView View;
        
    }
}

