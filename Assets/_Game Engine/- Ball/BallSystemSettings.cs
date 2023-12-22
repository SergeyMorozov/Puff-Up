using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class BallSystemSettings : ScriptableObject
    {
        public float BallAlpha;
        public float TextAlpha;
        public float ForceMoving;
        public List<BallObject> Balls;
    }
}
