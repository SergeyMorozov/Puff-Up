using UnityEngine;

namespace GAME
{
    public class JoystickSettings : ScriptableObject
    {
        public float SizeToScreen = 0.5f;
        public bool IsStatic;
        public Vector3 StaticViewPosition;
    }
}