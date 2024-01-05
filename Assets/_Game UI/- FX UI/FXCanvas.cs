using System;
using UnityEngine;

namespace GAME
{
    public class FXCanvas : MonoBehaviour
    {
        private static FXCanvas _instance;

        public static FXCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<FXCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public FXView View;
    }
}

