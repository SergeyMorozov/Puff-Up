using UnityEngine;

namespace  GAME
{
    public class LevelLogicClear : MonoBehaviour
    {
        private void Awake()
        {
            LevelSystem.Events.LevelEnd += LevelEnd;
            LevelSystem.Events.LevelClear += LevelClear;
        }

        private void LevelClear()
        {
            if (LevelSystem.Data.CurrentLevel != null)
            {
                Destroy(LevelSystem.Data.CurrentLevel.gameObject);
            }
        }

        private void LevelEnd()
        {
            if (LevelSystem.Data.CurrentLevel != null)
            {
                Destroy(LevelSystem.Data.CurrentLevel.gameObject);
            }
        }
    }
}

