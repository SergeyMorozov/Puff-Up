using System;
using UnityEngine;

namespace GAME
{
    public class LoadingCanvas : MonoBehaviour
    {
        private static LoadingCanvas _instance;

        public static LoadingCanvas Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<LoadingCanvas>();
                return _instance;
            }
        }

        // Events
        public Action Show;
        public Action Hide;
        
        // Views
        public LoadingView View;
    }
}

