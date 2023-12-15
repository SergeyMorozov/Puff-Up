using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class SoundLogic : MonoBehaviour
    {
        private void Awake()
        {
            SoundSystem.Events.SoundValue += SoundValue;
            SoundSystem.Events.PlaySound += PlaySound;
            SoundSystem.Events.PlaySoundPreset += PlaySoundPreset;
            SoundSystem.Events.PlaySoundLoop += PlaySoundLoop;
            SoundSystem.Events.StopSound += StopSound;
            SoundSystem.Events.StopSoundPreset += StopSoundPreset;
        }

        private void SoundValue(float value)
        {
            SoundSystem.Data.CurrentSoundVolume = Mathf.Clamp(value, 0, 1);
        }

        private void PlaySound(SoundObject sound, SoundPreset preset)
        {
            if (sound == null || sound.audioSource == null)
                return;

            sound.audioSource.clip = preset.Clip;
            sound.audioSource.volume = preset.Volume * SoundSystem.Data.CurrentSoundVolume;
            sound.audioSource.loop = preset.Loop;

            float pitch = Random.Range(preset.Pitch + preset.RandomPitchMin, preset.Pitch + preset.RandomPitchMax);
            sound.audioSource.pitch = pitch;
            
            sound.audioSource.Play();
        }
        
        private void PlaySoundPreset(SoundPreset preset)
        {
            if (preset == null)
                return;

            SoundObject sound = SoundSystem.Data.sounds.Find(s => s.Preset == preset);

            if (sound == null)
            {
                sound = Tools.AddObject<SoundObject>(SoundSystem.Transform);
                sound.name = preset.name;
                sound.Preset = preset;
                sound.audioSource = sound.gameObject.AddComponent<AudioSource>();
                sound.audioSource.clip = preset.Clip;
                sound.audioSource.loop = preset.Loop;
                SoundSystem.Data.sounds.Add(sound);
            }

            float pitch = Random.Range(preset.Pitch + preset.RandomPitchMin, preset.Pitch + preset.RandomPitchMax);
            sound.audioSource.pitch = pitch;
            sound.audioSource.volume = preset.Volume * SoundSystem.Data.CurrentSoundVolume;

            sound.audioSource.Play();
        }
        
        private void PlaySoundLoop(SoundObject sound)
        {
            if (sound == null || sound.audioSource == null)
                return;

            sound.audioSource.loop = true;
            sound.audioSource.Play();
        }
        
        private void StopSound(SoundObject sound)
        {
            if (sound == null || sound.audioSource == null)
                return;

            sound.audioSource.Stop();
        }
        
        private void StopSoundPreset(SoundPreset preset)
        {
            if (preset == null)
                return;

            SoundObject sound = SoundSystem.Data.sounds.Find(s => s.Preset == preset);
            
            if(sound == null)
                return;

            sound.audioSource.Stop();
        }

        
/*
        private SoundObject GetSoundByClip(SoundObject soundObject)
        {
            SoundObject sound = SoundSystem.Data.sounds.Find(s => s.clip == soundObject.clip);
            if (sound != null)
                return sound;
            
            soundObject.audioSource = Tools.AddObject<AudioSource>(transform);
            soundObject.audioSource.name = "Sound " + soundObject.clip.name;
            soundObject.audioSource.clip = soundObject.clip;
            SoundSystem.Data.sounds.Add(soundObject);
            sound = soundObject;
            return sound;
        }
*/        
    }
}
