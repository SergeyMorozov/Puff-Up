using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GAME
{
    public class BallSystemSettings : ScriptableObject
    {
        [Header("Ball Create")]
        public float BallAlphaMove;
        public float TextAlphaMove;
        public float BallMassMove;
        public float BallDragMove;
        public float BallGravityMove;
        public float ForceMoving;

        [Header("Ball Free")]
        public float BallAlphaFree;
        public float TextAlphaFree;
        public float BallMassFree;
        public float BallDragFree;
        public float BallGravityFree;

        [Space]
        public List<BallObject> Balls;
    }
}
