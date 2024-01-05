using System;
using System.Collections.Generic;
using UnityEngine;

namespace GAME
{
    public class PlayerLogicSaveLoad : MonoBehaviour
    {
        public struct PlayerStore
        {
            public float Money;
            public float Crystal;
        }

        private void Awake()
        {
            StoreGameSystem.Events.StoreDataLoad += StoreDataLoad;
            StoreGameSystem.Events.StoreDataSave += SaveStoreData;
        }

        private void StoreDataLoad()
        {
            StoreGameSystem.Events.LoadDataByType?.Invoke(new PlayerStore(), PlayerSystem.Settings.StoreName,
                DataByTypeLoaded);
        }

        private void DataByTypeLoaded(object data)
        {
            if (data == null || PlayerSystem.Settings.ClearSavedData)
            {
                // Нет сохранённых данных. Подставляем дефолтные 
                PlayerSystem.Data.PlayerStore = new PlayerStore()
                {
                    Money = PlayerSystem.Settings.Money,
                    Crystal = PlayerSystem.Settings.Crystal
                };
            }
            else
            {
                PlayerSystem.Data.PlayerStore = (PlayerStore) data;
            }
            
            PlayerSystem.Data.CurrentPlayer.Money = PlayerSystem.Data.PlayerStore.Money;
        }

        private void SaveStoreData()
        {
            PlayerStore playerStore = new PlayerStore();

            StoreGameSystem.Events.SaveDataByType?.Invoke(playerStore, PlayerSystem.Settings.StoreName, DataByTypeSaved);
        }

        private void DataByTypeSaved()
        {
            
        }
    }
}

