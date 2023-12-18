using System;
using System.Collections.Generic;
using UnityEngine;


namespace GAME
{
    public class LevelPreset : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public LevelObject Prefab;
    }
}

