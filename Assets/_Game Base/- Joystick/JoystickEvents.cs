using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GAME
{
    [Serializable]
    public class JoystickEvents
    {
        public Action<Vector3> JoystickDown;
        public Action<Vector3> JoystickUp;
        public Action<Vector3> JoystickTap;
        public Action<Vector3> JoystickSwipe;
        public Action<Button, EventTriggerType> OnEventTrigger;
    }
}
