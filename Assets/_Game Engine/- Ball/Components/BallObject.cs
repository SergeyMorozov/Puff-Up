using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GAME
{
    public class BallObject : MonoBehaviour
    {
        public BallPreset Preset;
        public BallRef Ref;

        [Space]
        public bool IsChainConnected;
        public float Value;
        public float ValueMax;
        public float Radius;
        public List<Collider2D> CollidersChain;
        public List<Collider2D> CollidersBalls;
        public List<BallObject> ConnectedBalls;

        private void OnTriggerEnter2D(Collider2D other)
        {
            BallSystem.Events.BallColliderEnter?.Invoke(this, other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            BallSystem.Events?.BallColliderExit?.Invoke(this, other);
        }

    }


}

