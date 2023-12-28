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
            
            int index = LevelSystem.Data.LevelNumber - 1;
            LevelPreset levelPreset = LevelSystem.Settings.Levels[index]; 
            LevelObject level = Tools.AddObject<LevelObject>(null);
            level.Preset = levelPreset;
            level.name = levelPreset.name;

            SetCups();
            
            LevelSystem.Data.CurrentLevel = level;
            LevelSystem.Events.LevelLoaded?.Invoke();
        }

        private void SetCups()
        {
            
        }
    }
}

