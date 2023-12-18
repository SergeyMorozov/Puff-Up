using UnityEngine;

namespace  GAME
{
    public class PlayerLogic : MonoBehaviour
    {
        private PlayerObject _player;
        
        private void Awake()
        {
            _player = PlayerSystem.Data.CurrentPlayer;
        }
    }
}

