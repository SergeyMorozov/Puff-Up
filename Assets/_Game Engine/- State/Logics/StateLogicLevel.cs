using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class StateLogicLevel : MonoBehaviour
    {
        private StateDataLevel _stateData;
        private StateDataLevelComplete _stateDataComplete;
        private StateDataLevelFail _stateDataFail;

        private void Awake()
        {
            _stateData = StateSystem.Data.StateDataLevel;
            _stateDataComplete = StateSystem.Data.StateDataLevelComplete;
            _stateDataFail = StateSystem.Data.StateDataLevelFail;

            StateSystem.Events.StateEnter += StateEnter;
            LevelSystem.Events.LevelLoaded += LevelLoaded;
            LevelSystem.Events.LevelFinish += LevelFinish;
            LevelSystem.Events.LevelComplete += LevelComplete;
            LevelSystem.Events.LevelFail += LevelFail;
            LevelSystem.Events.LevelClaimRewards += LevelClaimRewards;
            LevelSystem.Events.LevelFailClose += LevelFailClose;
            LevelSystem.Events.LevelContinue += LevelContinue;
        }

        private void StateEnter(StateData data)
        {
            if (_stateData.IsActive) StateExit();
            if(data.GetType() != typeof(StateDataLevel)) return;
            
            _stateData.IsActive = true;
            _stateData.IsShow = true;
            _stateData.LevelState = LevelState.Loading;
            LevelSystem.Events.LevelLoad?.Invoke();
        }

        private void LevelLoaded()
        {
            StateSystem.Data.StateDataLevel.Level = LevelSystem.Data.CurrentLevel;
        }

        private void LevelFinish()
        {
            _stateData.LevelState = LevelState.Finish;
        }

        private void LevelComplete()
        {
            _stateData.LevelState = LevelState.Complete;

            _stateDataComplete.IsActive = true;
            _stateDataComplete.IsShow = true;
            /*_stateDataComplete.Movies = BaseSphereSystem.Data.CurrentBaseSphere.Movies;
            _stateDataComplete.Rewards = new List<ItemData>();
            
            foreach (ItemData reward in LevelSystem.Data.CurrentLevel.Preset.Rewards)
            {
                ItemData item = new ItemData { Preset = reward.Preset, Value = reward.Value };
                if (reward.Value < reward.ValueMax)
                    item.Value = Random.Range((int)reward.Value, (int)(reward.ValueMax + 1));

                _stateDataComplete.Rewards.Add(item);
            }

            if (_stateData.Level.Preset.Timer > 0)
            {
                // Сбор на время
                float result = _stateData.Level.Preset.GoalBalls[0].Value - _stateData.Level.BaseSphere.Goals[0].Value;
                _stateDataComplete.Rewards[2].Value = result;
            }*/
        }

        private void LevelClaimRewards()
        {
            PlayerObject player = PlayerSystem.Data.CurrentPlayer;
            
            /*if(player.CurrentLevel <= LevelSystem.Data.LevelNumber)
                player.CurrentLevel = LevelSystem.Data.LevelNumber + 1;

            foreach (ItemData reward in _stateDataComplete.Rewards)
            {
                PlayerSystem.Events.AddReward?.Invoke(reward);
            }*/

        }

        private void LevelFail()
        {
            _stateData.LevelState = LevelState.Fail;

            _stateDataFail.IsActive = true;
            _stateDataFail.IsShow = true;
            _stateDataFail.Movies = 0;
            
            // GameFailCanvas.Instance.ShowBuyMoves?.Invoke(LevelSystem.Data.CurrentLevel.Preset.FailData);
        }

        private void LevelFailClose()
        {
            StateSystem.Events.StateLevelToBase?.Invoke();
        }

        private void LevelContinue()
        {
            _stateData.LevelState = LevelState.Continue;
        }

        private void Update()
        {
            if(!_stateData.IsActive) return;

            switch (_stateData.LevelState)
            {
                case LevelState.Loading:
                    if (LevelSystem.Data.CurrentLevel != null)
                    {
                        _stateData.LevelState = LevelState.Init;
                        LevelSystem.Events.LevelInit?.Invoke();
                    }
                    break;
                
                case LevelState.Init:
                    /*
                    if (BaseSphereSystem.Data.CurrentBaseSphere != null &&
                        BaseSphereSystem.Data.CurrentBaseSphere.IsReady)
                    {
                        LevelSystem.Events.LevelLoaded?.Invoke();
                        _stateData.LevelState = LevelState.Spawn;
                    }
                    */
                    break;
                
                case LevelState.Spawn:
                    LevelSystem.Events.LevelStart?.Invoke();
                    // BaseSphereSystem.Events.MoviesChanged?.Invoke();
                    // BaseSphereSystem.Events.GoalChanged?.Invoke();
                    _stateData.LevelState = LevelState.Play;
                    break;

                case LevelState.Play:
                    // _stateData.Level.BaseSphere.Timer.IsActive = true;
                    break;

                case LevelState.Finish:
                    // _stateData.Level.BaseSphere.Timer.IsActive = false;
                    break;

                case LevelState.Complete:
                    break;

                case LevelState.Fail:
                    break;

                case LevelState.Continue:
                    _stateDataFail.IsActive = false;
                    _stateDataFail.IsShow = false;
                    _stateData.LevelState = LevelState.Play;
                    // BaseSphereSystem.Data.CurrentBaseSphere.IsFinish = false;
                    // BaseSphereSystem.Data.CurrentBaseSphere.IsRotated = true;
                    break;

                case LevelState.Exit:
                    break;
            }
        }

        private void StateExit()
        {
            _stateData.IsActive = false;
            _stateDataComplete.IsActive = false;
            _stateDataComplete.IsShow = false;
            _stateDataFail.IsActive = false;
            _stateDataFail.IsShow = false;
            
            Destroy(LevelSystem.Data.CurrentLevel.gameObject);
        }
        
    }
}


