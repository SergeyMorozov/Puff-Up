using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class LevelSystemData
    {
        public LevelStateData State;
        
        public LevelPreset LevelPreset;
        public LevelObject CurrentLevel;

        [Space]
        public LevelLogicSaveLoad.LevelStore LevelStore;
        public int LevelNumber;
        public int LevelCount;
        public int LevelLoop;

        public float TimeStart;
        public float Progress;    // Range 0-100
        public bool IsWin;
    }
    
    [Serializable]
    public class LevelStateData : GameStateData
    {
        public LevelObject Level;
        public LevelState LevelState;
    }

    
}
