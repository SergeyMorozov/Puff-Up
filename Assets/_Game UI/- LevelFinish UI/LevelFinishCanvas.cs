using System;
using UnityEngine;

namespace GAME
{
    public class LevelFinishCanvas : MonoBehaviour
    {
        private static LevelFinishCanvas _instance;

        public static LevelFinishCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<LevelFinishCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public LevelFinishView View;
    }
}

