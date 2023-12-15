using System;

namespace GAME
{
    [Serializable]
    public class SoundEvents
    {
        public Action<float> SoundValue;
        public Action<SoundObject, SoundPreset> PlaySound;
        public Action<SoundPreset> PlaySoundPreset;
        public Action<SoundObject, float> PlaySoundDelay;
        public Action<SoundObject, float, int> PlaySoundDelayIndex;
        public Action<SoundObject> PlaySoundLoop;
        public Action<SoundObject, float> PlaySoundLoopDelay;
        public Action<SoundObject> StopSound;
        public Action<SoundPreset> StopSoundPreset;
        public Action<SoundObject> StopSoundLoop;
    
    }
}