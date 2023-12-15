using System;

namespace GAME
{
    [Serializable]
    public class VibrationEvents
    {
        public Action VibrationOn;
        public Action VibrationOff;
        public Action<VibrationEnum> VibrationPlay;
        public Action<VibrationEnum, float> VibrationPlayDelay;
    }
}