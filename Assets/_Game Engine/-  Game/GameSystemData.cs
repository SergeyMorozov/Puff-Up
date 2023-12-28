using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace GAME
{
    [Serializable]
    public class GameSystemData
    {
        public bool IsFadeActive;
        public float FadeValue;
        
        [Space]
        public bool GamePause;
    }

    [Serializable]
    public class GameStateData
    {
        public bool IsReady;
        public bool IsActive;
        public bool IsShow;
    }
    

}