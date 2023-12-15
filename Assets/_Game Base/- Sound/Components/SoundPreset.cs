using UnityEngine;

namespace GAME
{
    public class SoundPreset : ScriptableObject
    {
        public AudioClip Clip;
        [Range(0f, 1f)]
        public float Volume = 1;
        [Range(-2f, 2f)]
        public float Pitch = 1;
        [Range(-1f, 1f)]
        public float RandomPitchMin = 0;
        [Range(-1f, 1f)]
        public float RandomPitchMax = 0;

        public bool Loop;
        
    }
}
