using System;
using UnityEngine;

namespace  GAME
{
    public class LoadingLogic : MonoBehaviour
    {
        private LoadingSystemData _data;
        
        private void Awake()
        {
            _data = LoadingSystem.Data;
            
            LoadingSystem.Events.AppLoad += AppLoad;
        }

        private void AppLoad()
        {
            StoreGameSystem.Events.StoreDataLoad?.Invoke();

            _data.IsActive = true;
            _data.IsShow = true;
        }

        private void Update()
        {
            if(!_data.IsActive || !_data.IsShow) return;

            _data.Value += Time.deltaTime / LoadingSystem.Settings.FakeTimeLoading;
            
            if(_data.Value < 1) return;

            _data.Value = 1;
            _data.IsActive = false;
            
            LoadingSystem.Events.AppLoadComplete?.Invoke(Close);
        }

        private void Close()
        {
            _data.IsShow = false;
        }
    }
}

