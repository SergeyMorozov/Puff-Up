using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class BallObject : MonoBehaviour
    {
        public BallPreset Preset;
        public BallRef Ref;

        public float Value;
        public float Radius;
        public Vector3 LastPosition;
        public Vector3 LastScale;
        public float LastValue;
        public List<Collider2D> Colliders;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (Colliders.Contains(other)) return;
            // Debug.Log("+++ " + other.name);
            Colliders.Add(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Colliders.Remove(other);
            // Debug.Log("------ " + other.name);
        }

    }


}

