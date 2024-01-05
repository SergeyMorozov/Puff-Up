using System;
using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class StoreGameLogic : MonoBehaviour
    {
        private void Awake()
        {
            StoreGameSystem.Data.status = new Dictionary<string, StoreStatus>();
            
            StoreGameSystem.Events.LoadDataByType += LoadDataByType;
            StoreGameSystem.Events.SaveDataByType += SaveDataByType;
        }

        private void LoadDataByType<T>(T type, string storeName, Action<object> callBack)
        {
            if (StoreGameSystem.Data.Status != StoreStatus.Loading)
            {
                Debug.Log("StoreData Loading <<<===");
                StoreGameSystem.Data.Status = StoreStatus.Loading;
            }
            
//            Debug.Log("LoadDataByType " + type + " " + storeName + " Loading");
            StoreGameSystem.Data.status.Add(type.ToString(), StoreStatus.Loading);

            // Код загрузки данных
            T data = (T)Tools.GetDataFromPrefs(storeName, type);

//            Debug.Log("LoadDataByType " + type + " " + storeName + " Complete");
            StoreGameSystem.Data.status[type.ToString()] = StoreStatus.Complete;
            callBack?.Invoke(data);
        }

        private void SaveDataByType<T>(T data, string storeName, Action callBack)
        {
            if (StoreGameSystem.Data.Status != StoreStatus.Saving)
            {
                Debug.Log("StoreData Saving ===>>>");
                StoreGameSystem.Data.Status = StoreStatus.Saving;
            }
            
//            Debug.Log("SaveDataByType " + data.GetType() + " " + storeName + " Saving");
            string key = data.GetType().ToString();
            if(StoreGameSystem.Data.status.ContainsKey(key)) return;
            StoreGameSystem.Data.status.Add(key, StoreStatus.Loading);

            // Код сохранения данных
            Tools.SetDataToPrefs(storeName, data);

//            Debug.Log("SaveDataByType " + data.GetType() + " " + storeName + " Complete");
            StoreGameSystem.Data.status[key] = StoreStatus.Complete;
            callBack?.Invoke();
        }


        private void LateUpdate()
        {
            if (StoreGameSystem.Data.Status == StoreStatus.Loading ||
                StoreGameSystem.Data.Status == StoreStatus.Saving)
            {
                foreach (var pair in StoreGameSystem.Data.status)
                {
                    if(pair.Value == StoreStatus.Complete)
                    {
//                        Debug.Log("StoreFeature " + StoreSystem.Data.Status + ": " + pair.Key + " Complete");
                        StoreGameSystem.Data.status.Remove(pair.Key);
                        break;
                    }
                    
                    if(pair.Value == StoreStatus.Error)
                    {
//                        Debug.LogError("StoreFeature " + StoreSystem.Data.Status + ": " + pair.Key + " Error");
                        StoreGameSystem.Data.status.Remove(pair.Key);
                        break;
                    }
                }

                if (StoreGameSystem.Data.status.Count == 0)
                {
                    if (StoreGameSystem.Data.Status == StoreStatus.Loading)
                    {
                        Debug.Log("StoreData Load Complete");
                        StoreGameSystem.Data.Status = StoreStatus.Complete;
                        StoreGameSystem.Events.StoreDataLoaded?.Invoke();
                        return;
                    }

                    if (StoreGameSystem.Data.Status == StoreStatus.Saving)
                    {
                        Debug.Log("StoreData Save Complete");
                        StoreGameSystem.Data.Status = StoreStatus.Complete;
                        StoreGameSystem.Events.StoreDataSaved?.Invoke();
                        return;
                    }
                }
            }
            
        }
    }
}
