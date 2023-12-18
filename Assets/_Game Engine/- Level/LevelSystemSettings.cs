using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class LevelSystemSettings : ScriptableObject
    {
        public string StoreName = "level_data";
        public bool ClearSavedData;
        public int StartLevelLoop = 2;
        public List<LevelPreset> Levels;
    }
}
