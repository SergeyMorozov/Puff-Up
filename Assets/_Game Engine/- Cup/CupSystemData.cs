using System;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace GAME
{
    [Serializable]
    public class CupSystemData
    {
        public CupObject CurrentCup;
        public int Index;
        public List<CupObject> Cups;
    }
}
