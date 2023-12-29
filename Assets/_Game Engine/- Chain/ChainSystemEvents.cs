using System;

namespace GAME
{
    [Serializable]
    public class ChainSystemEvents
    {
        public Action<ChainObject> ChainDestroy;
    }
}
