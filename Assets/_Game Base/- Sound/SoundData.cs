using System;
using System.Collections.Generic;

namespace GAME
{
    [Serializable]
    public class SoundData
    {
        public float CurrentSoundVolume;
        public float CurrentMusicVolume;

        public List<SoundObject> sounds;
    }
}