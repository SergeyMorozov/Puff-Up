using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class ChainObject : MonoBehaviour
    {
        public ChainPreset Preset;
        public ChainRef Ref;

        public float Value;
        public List<Collider2D> Colliders;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Colliders.Contains(other)) return;
            Colliders.Add(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Colliders.Remove(other);
        }
    }
}

