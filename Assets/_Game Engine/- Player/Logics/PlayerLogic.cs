using UnityEngine;

namespace  GAME
{
    public class PlayerLogic : MonoBehaviour
    {
        private PlayerObject _player;
        
        private void Awake()
        {
            _player = PlayerSystem.Data.CurrentPlayer;
            
            LevelSystem.Events.LevelLoaded += LevelLoaded;
        }

        private void LevelLoaded()
        {
            _player.Moves = LevelSystem.Data.CurrentLevel.Preset.StartMoves;
        }
    }
}

