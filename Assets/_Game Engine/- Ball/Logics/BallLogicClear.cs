using UnityEngine;

namespace  GAME
{
    public class BallLogicClear : MonoBehaviour
    {
        private void Awake()
        {
            LevelSystem.Events.LevelClear += LevelClear;
        }

        private void LevelClear()
        {
            foreach (BallObject ball in BallSystem.Data.Balls)
            {
                Destroy(ball.gameObject);
            }
            
            BallSystem.Data.Balls.Clear();
        }
    }
}

