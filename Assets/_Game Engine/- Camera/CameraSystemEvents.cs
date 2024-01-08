using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class CameraSystemEvents
    {
        public Action<Vector3, bool> SetCameraPoint;
        public Action<Transform, bool> SetCameraTarget;
    }
}
