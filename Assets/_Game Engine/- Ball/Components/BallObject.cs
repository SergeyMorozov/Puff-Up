using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class BallObject : MonoBehaviour
    {
        public BallPreset Preset;
        public BallRef Ref;
        
        public float Value;
        public List<Collision> Collisions;

        private void OnCollisionEnter(Collision other)
        {
            if(Collisions.Contains(other)) return;
            Collisions.Add(other);
        }
        
        private void OnCollisionExit(Collision other)
        {
            Collisions.Remove(other);
        }

    }
    
    
}

