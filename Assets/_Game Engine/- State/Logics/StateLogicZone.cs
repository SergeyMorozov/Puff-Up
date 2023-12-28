using UnityEngine;

namespace  GAME
{
    public class StateLogicZone : MonoBehaviour
    {
        private StateDataZone _stateData;

        private void Awake()
        {
            _stateData = StateSystem.Data.StateDataZone;

            StateSystem.Events.StateEnter += StateEnter;
        }

        private void StateEnter(StateData data)
        {
            if (_stateData.IsActive) StateExit();
            if(data.GetType() != typeof(StateDataZone)) return;
            
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

