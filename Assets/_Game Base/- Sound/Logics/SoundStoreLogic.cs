using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class SoundStoreLogic : MonoBehaviour
    {
        private struct SoundStore
        {
            public float SoundVolume;
            public float MusicVolume;
        }

        private void Awake()
        {
//            StoreSystemOld.Events.LoadStoreData += LoadStoreData;
//            StoreSystemOld.Events.SaveStoreData += SaveStoreData;

            InitDefaultSettings();
        }

        private void InitDefaultSettings()
        {
            SoundSystem.Data.sounds = new List<SoundObject>();
            SoundSystem.Data.CurrentSoundVolume = SoundSystem.Settings.SoundVolume;
            SoundSystem.Data.CurrentMusicVolume = SoundSystem.Settings.MusicVolume;
        }

        private void LoadStoreData()
        {
//            StoreSystem.Events.LoadDataByType?.Invoke(new SoundStore(), SoundSystem.Settings.StoreName, DataByTypeLoaded);
        }

        private void DataByTypeLoaded(object data)
        {
            if (data == null)
            {
                // Нет сохранённых данных. Подставляем дефолтные значения
                InitDefaultSettings();
            }
            else
            {
                SoundStore soundStore = (SoundStore) data;
                SoundSystem.Data.sounds = new List<SoundObject>();
                SoundSystem.Data.CurrentSoundVolume = soundStore.SoundVolume;
                SoundSystem.Data.CurrentMusicVolume = soundStore.MusicVolume;
            }
        }

        private void SaveStoreData()
        {
            SoundStore soundStore = new SoundStore
            {
                SoundVolume = SoundSystem.Data.CurrentSoundVolume,
                MusicVolume = SoundSystem.Data.CurrentMusicVolume
            };
//            StoreSystem.Events.SaveDataByType?.Invoke(soundStore, SoundSystem.Settings.StoreName, DataByTypeSaved);
        }

        private void DataByTypeSaved()
        {
            
        }
    }
    
}
