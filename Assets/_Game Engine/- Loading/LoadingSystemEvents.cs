using System;

namespace GAME
{
    [Serializable]
    public class LoadingSystemEvents
    {
        public Action AppLoad;
        public Action<Action> AppLoadComplete;
    }
}
