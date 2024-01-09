using System;
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
            BallSystem.Events.BallCreated += BallCreated;
            LevelSystem.Events.CupLoaded += CupLoaded;
        }

        private void LevelLoaded()
        {
            _player.Moves = LevelSystem.Data.CurrentLevel.Preset.StartMoves;
        }
        
        private void BallCreated(BallObject ball)
        {
            _player.Moves--;

            if (_player.Moves < 0 && LevelSystem.Data.IsPlay)
            {
                _player.Moves = 0;
                LevelSystem.Events.LevelFinish?.Invoke();
            }
        }

        private void CupLoaded()
        {
            _player.Moves += LevelSystem.Data.CurrentLevel.Preset.AddMoves;
        }

        private void Update()
        {
            if (_player.MovesLast == _player.Moves) return;

            _player.MovesDist += Time.deltaTime / 2;
            _player.MovesLast = Mathf.Lerp(_player.MovesLast, _player.Moves, _player.MovesDist);
            
            if (Mathf.Abs(_player.MovesLast - _player.Moves) <= 1)
            {
                _player.MovesLast = _player.Moves;
                _player.MovesDist = 0;
            }
        }
    }
}

