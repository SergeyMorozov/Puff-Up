using System;

namespace GAME
{
    [Serializable]
    public class GameSystemEvents
    {
        public Action GameInit;
        public Action GameReady;
    }
}