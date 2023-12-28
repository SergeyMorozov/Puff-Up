using System;
using UnityEngine;

namespace GAME
{
    public class FadeCanvas : MonoBehaviour
    {
        private static FadeCanvas _instance;

        public static FadeCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<FadeCanvas>();
                return _instance;
            }
        }

        // Events
        public Action ShowFade;
        public Action HideFade;
        
        // Views
        public FadeView View;
    }
}

