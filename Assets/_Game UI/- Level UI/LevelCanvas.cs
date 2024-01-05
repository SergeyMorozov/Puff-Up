using System;
using UnityEngine;

namespace GAME
{
    public class LevelCanvas : MonoBehaviour
    {
        private static LevelCanvas _instance;

        public static LevelCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<LevelCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public LevelView View;
    }
}

