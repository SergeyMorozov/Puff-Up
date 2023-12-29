using System;
using System.Collections;
using UnityEngine;

namespace  GAME
{
    public class LevelLogicFinish : MonoBehaviour
    {
        private LevelObject _level;
        private float _timerCheckFinish;
        
        private void Awake()
        {
            LevelSystem.Events.LevelLoaded += LevelLoaded;
            ChainSystem.Events.ChainDestroy += ChainDestroy;
        }

        private void LevelLoaded()
        {
            _level = LevelSystem.Data.CurrentLevel;
        }

        private void ChainDestroy(ChainObject obj)
        {
            
        }
    }
}

