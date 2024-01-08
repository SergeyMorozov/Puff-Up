using UnityEngine;

namespace  GAME
{
    public class LevelLogicComplete : MonoBehaviour
    {
        private PlayerObject _player;
        
        private void Awake()
        {
            _player = PlayerSystem.Data.CurrentPlayer;
            
            LevelSystem.Events.LevelFinish += LevelFinish;
        }

        private void LevelFinish()
        {
            if(_player.Moves <= 0 && CupSystem.Data.Index < CupSystem.Data.Cups.Count - 1) return;

            LevelSystem.Data.IsWin = true;
            LevelSystem.Events.LevelComplete?.Invoke();
        }

    }
}

