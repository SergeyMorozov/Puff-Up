using UnityEngine;

namespace  GAME
{
    public class StateLogicInventory : MonoBehaviour
    {
        private StateDataInventory _stateData;

        private void Awake()
        {
            _stateData = StateSystem.Data.StateDataInventory;

            StateSystem.Events.StateEnter += StateEnter;
        }

        private void StateEnter(StateData data)
        {
            if (_stateData.IsActive) StateExit();
            if(data.GetType() != typeof(StateDataInventory)) return;
            
            _stateData.IsActive = true;
            _stateData.IsShow = true;
        }

        private void Update()
        {
            if(!_stateData.IsActive) return;
        }

        private void StateExit()
        {
            _stateData.IsActive = false;
        }
    }
}

