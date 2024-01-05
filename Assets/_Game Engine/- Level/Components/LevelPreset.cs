using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace GAME
{
    public class LevelPreset : ScriptableObject
    {
        public int StartMoves;
        public int AddMoves;
        public List<int> Chains;
        public List<CupObject> Cups;
    }
}

