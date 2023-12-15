using MoreMountains.NiceVibrations;
using UnityEngine;

namespace  GAME
{
    public class VibrationLogic : MonoBehaviour
    {
        private float _timeNextVibration;
        
        private void Awake()
        {
            VibrationSystem.Events.VibrationOn += VibrationOn;
            VibrationSystem.Events.VibrationOff += VibrationOff;
            VibrationSystem.Events.VibrationPlay += VibrationPlay;
        }

        private void VibrationOn()
        {
            VibrationSystem.Data.CurrentVibrationVolume = 1;
        }
        
        private void VibrationOff()
        {
            VibrationSystem.Data.CurrentVibrationVolume = 0;
        }

        private void VibrationPlay(VibrationEnum vibrationType)
        {
            if(_timeNextVibration > Time.time ||
               VibrationSystem.Data.CurrentVibrationVolume == 0)
                return;

            _timeNextVibration = Time.time + VibrationSystem.Settings.delayNextVibration;
            
            switch (vibrationType)
            {
                case VibrationEnum.LowShort:
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    break;
                case VibrationEnum.LowMiddle:
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    break;
                case VibrationEnum.LowLong:
                    MMVibrationManager.Haptic(HapticTypes.LightImpact);
                    break;
                case VibrationEnum.NormalShort:
                    MMVibrationManager.Haptic(HapticTypes.MediumImpact);
                    break;
                case VibrationEnum.NormalMiddle:
                    MMVibrationManager.Haptic(HapticTypes.MediumImpact);
                    break;
                case VibrationEnum.NormalLong:
                    MMVibrationManager.Haptic(HapticTypes.MediumImpact);
                    break;
                case VibrationEnum.HighShort:
                    MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
                    break;
                case VibrationEnum.HighMiddle:
                    MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
                    break;
                case VibrationEnum.HighLong:
                    MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
                    break;
            }
        }

    }
}
