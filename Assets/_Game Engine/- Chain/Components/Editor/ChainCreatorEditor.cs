using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GAME
{
    [CustomEditor(typeof(ChainCreator)), CanEditMultipleObjects]
    public class ChainCreatorEditor : Editor
    {
        private ChainCreator _chainCreator;

        void OnEnable()
        {
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            _chainCreator = (ChainCreator)target;
            _chainCreator.UpdateChain();
        }
    }
    
    
}

