using System;
using UnityEngine;

namespace GAME
{
    [Serializable]
    public class JoystickData
    {
        public Vector3 DirectValue;
        public Vector3 Direct;
        public float Value;

        [Space]
        public bool BlockInput;
        public bool MousePressed;
        public bool IsLock;
        
        [Space]
        public Vector3 JoystickPosition;
        public Vector3 MousePosition;
        public Transform JoystickWorldPoint;
    }
}