using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class BallSystemEvents
    {
        public Func<Vector3, float, CheckPlace> CheckFreePlace;
        public Func<float, CheckPlace> CheckFreePlaceOnScreen;
        public Action<BallObject, Collider2D> BallColliderEnter;
        public Action<BallObject, Collider2D> BallColliderExit;
        public Action<BallObject> BallCreated;
        public Action<BallObject> BallConnected;
    }
}
