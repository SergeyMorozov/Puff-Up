using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class BallSystemEvents
    {
        public Func<Vector3, float, CheckPlace> CheckFreePlace;
        public Func<float, CheckPlace> CheckFreePlaceOnScreen;
    }
}
