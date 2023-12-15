using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class VibrationSettings : ScriptableObject
    {
        public string StoreName = "vibration";
        public float Volume = 1f;
        public float delayNextVibration = 0.2f;
    }
}