using UnityEngine;

namespace  GAME
{
    public class StateLogicAppLoading : MonoBehaviour
    {
        private StateDataAppLoading _stateData;
        private bool _isStoreLoaded;

        private void Awake()
        {
            _stateData = StateSystem.Data.StateDataAppLoading;
            
            StateSystem.Events.StateEnter += StateEnter;
            StoreGameSystem.Events.StoreDataLoaded += StoreDataLoaded;
        }

        private void StateEnter(StateData data)
        {
            if (_stateData.IsActive) StateExit();
            if(data.GetType() != typeof(StateDataAppLoading)) return;

            _stateData.IsActive = true;
            _stateData.IsShow = true;
            
            // Загрузка предыдущих сохранённых данных
            _isStoreLoaded = false;
            StoreGameSystem.Events.StoreDataLoad?.Invoke();
        }

        private void Update()
        {
            if(!_stateData.IsActive) return;

            _stateData.Value += Time.deltaTime / StateSystem.Settings.FakeTimeLoading;
            
            if(_stateData.Value < 1) return;
            _stateData.Value = 1;

            if(_isStoreLoaded) StateExit();
        }

        private void StateExit()
        {
            _stateData.IsActive = false;
            _stateData.CallBackExit?.Invoke();
        }

        private void StoreDataLoaded()
        {
            _isStoreLoaded = true;
        }
    }
}

