using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class LevelLogicSaveLoad : MonoBehaviour
    {
        public struct LevelStore
        {
            public int LevelNumber;
        }

        private void Awake()
        {
            StoreGameSystem.Events.StoreDataLoad += StoreDataLoad;
            StoreGameSystem.Events.StoreDataSave += SaveStoreData;
        }

        private void StoreDataLoad()
        {
            StoreGameSystem.Events.LoadDataByType?.Invoke(new LevelStore(), LevelSystem.Settings.StoreName,
                DataByTypeLoaded);
        }

        private void DataByTypeLoaded(object data)
        {
            if (data == null || LevelSystem.Settings.ClearSavedData)
            {
                // Нет сохранённых данных. Подставляем дефолтные 
                LevelSystem.Data.LevelStore = new LevelStore{};
                LevelSystem.Data.LevelNumber = 1;
            }
            else
            {
                LevelStore levelStore = (LevelStore) data;
                LevelSystem.Data.LevelStore = levelStore;
                LevelSystem.Data.LevelNumber = levelStore.LevelNumber;
            }
        }

        private void SaveStoreData()
        {
            LevelStore levelStore = new LevelStore
            {
                LevelNumber = LevelSystem.Data.LevelNumber,
            };
            StoreGameSystem.Events.SaveDataByType?.Invoke(levelStore, LevelSystem.Settings.StoreName, DataByTypeSaved);
        }

        private void DataByTypeSaved()
        {

        }
    }
}