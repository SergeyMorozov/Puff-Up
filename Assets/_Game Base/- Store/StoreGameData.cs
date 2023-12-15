using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class StoreGameData
    {
        public StoreStatus Status;
        public Dictionary<string, StoreStatus> status;
    }
    
    public enum StoreStatus
    {
        None = 0,
        Loading = 1,
        Saving = 2,
        Complete = 3,
        Error = 4,
    }
}