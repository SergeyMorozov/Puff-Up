using UnityEngine;

namespace  GAME
{
    public class LevelLogicLoading : MonoBehaviour
    {
        private void Awake()
        {
            LevelSystem.Events.LevelLoad += LevelLoad;
        }

        private void LevelLoad()
        {
            LevelSystem.Data.IsWin = false;
            LevelPreset levelPreset = LevelSystem.Data.LevelPreset; 
            // LevelObject level = Tools.AddObject<LevelObject>(levelPreset.Prefab, null);
            // level.Preset = levelPreset;
            // level.name = levelPreset.name;
            // LevelSystem.Data.CurrentLevel = level;
            // LevelSystem.Data.LevelNumber = LevelSystem.Settings.Levels.FindIndex(l => l == levelPreset) + 1;
        }
    }
}

