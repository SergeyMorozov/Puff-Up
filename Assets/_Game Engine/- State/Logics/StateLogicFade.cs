using UnityEngine;

namespace  GAME
{
    public class StateLogicFade : MonoBehaviour
    {
        private StateDataFade _stateData;

        private void Awake()
        {
            _stateData = StateSystem.Data.StateDataFade;

            StateSystem.Events.StateEnterWithFade += StateEnter;
        }

        private void StateEnter(StateData dataIn, StateData dataOut)
        {
            _stateData.IsActive = true;
            _stateData.IsFade = true;
            _stateData.Value = 0;
            _stateData.DataIn = dataIn;
            _stateData.DataOut = dataOut;
        }

        private void Update()
        {
            if(!_stateData.IsActive) return;

            if (_stateData.IsFade)
            {
                _stateData.Value += Time.deltaTime / StateSystem.Settings.TimeFade;
                if (_stateData.Value >= 1)
                {
                    _stateData.IsFade = false;
                    _stateData.Value = 1;
                    _stateData.DataIn.IsShow = false;
                    StateSystem.Events.StateEnter?.Invoke(_stateData.DataOut);
                }
            }
            else
            {
                _stateData.Value -= Time.deltaTime / StateSystem.Settings.TimeFade;
                if (_stateData.Value <= 0)
                {
                    _stateData.Value = 0;
                    _stateData.IsActive = false;
                }
            }
        }
    }
}

