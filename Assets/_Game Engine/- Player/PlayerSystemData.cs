using System;

namespace GAME
{
    [Serializable]
    public class PlayerSystemData
    {
        public PlayerLogicSaveLoad.PlayerStore PlayerStore;
        public PlayerObject CurrentPlayer;
    }
}
