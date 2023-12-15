using UnityEngine;

namespace  GAME
{
    public class VibrationStoreLogic : MonoBehaviour
    {
        private struct VibrationStore
        {
            public float Volume;
        }

        private void Awake()
        {
//            StoreSystemOld.Events.LoadStoreData += LoadStoreData;
//            StoreSystemOld.Events.SaveStoreData += SaveStoreData;

            InitDefaultSettings();
        }

        private void InitDefaultSettings()
        {
            VibrationSystem.Data.CurrentVibrationVolume = VibrationSystem.Settings.Volume;
        }

        private void LoadStoreData()
        {
//            StoreSystem.Events.LoadDataByType?.Invoke(new VibrationStore(), VibrationSystem.Settings.StoreName, DataByTypeLoaded);
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
                VibrationStore vibrationStore = (VibrationStore) data;
                VibrationSystem.Data.CurrentVibrationVolume = vibrationStore.Volume;
            }
        }

        private void SaveStoreData()
        {
            VibrationStore vibrationStore = new VibrationStore
            {
                Volume = VibrationSystem.Data.CurrentVibrationVolume,
            };
//            StoreSystem.Events.SaveDataByType?.Invoke(vibrationStore, VibrationSystem.Settings.StoreName, DataByTypeSaved);
        }

        private void DataByTypeSaved()
        {
            
        }
    }
}
