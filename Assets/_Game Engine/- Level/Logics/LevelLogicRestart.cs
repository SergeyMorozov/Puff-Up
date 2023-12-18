using UnityEngine;

namespace  GAME
{
    public class LevelLogicRestart : MonoBehaviour
    {
        private void Awake()
        {
            LevelSystem.Events.LevelRestart += LevelRestart;
        }

        private void LevelRestart()
        {
            if (LevelSystem.Data.IsWin)
            {
            }
            
            LevelSystem.Data.IsWin = false;
            
            Destroy(LevelSystem.Data.CurrentLevel.gameObject);

            LevelPreset levelPreset = LevelSystem.Settings.Levels[0];
            LevelObject level = Tools.AddObject<LevelObject>(levelPreset.Prefab, null);
            LevelSystem.Data.CurrentLevel = level;
            
            LevelSystem.Events.LevelLoad?.Invoke();
        }

    }
}

