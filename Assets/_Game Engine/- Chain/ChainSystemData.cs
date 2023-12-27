using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace GAME
{
    [Serializable]
    public class ChainSystemData
    {
        public ChainObject CurrentChain;
        public List<ChainObject> Chains;
    }
}
