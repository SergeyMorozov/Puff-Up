using UnityEngine;
using Random = UnityEngine.Random;

namespace  GAME
{
    public class StateLogic : MonoBehaviour
    {
        private void Awake()
        {
            Random.InitState(0);
            Application.targetFrameRate = 1000;
            
            StateSystem.Events.StateMainMenu += StateMainMenu;
            StateSystem.Events.StateSkills += StateSkills;
            StateSystem.Events.StateSkillsBack += StateSkillsBack;
            StateSystem.Events.StateInventory += StateInventory;
            StateSystem.Events.StateInventoryBack += StateInventoryBack;
            StateSystem.Events.StateMap += StateMap;
            StateSystem.Events.StateMapBack += StateMapBack;
            StateSystem.Events.StateZone += StateZone;
            StateSystem.Events.StateZoneBack += StateZoneBack;
            StateSystem.Events.StateLevel += StateLevel;
            StateSystem.Events.StateLevelToBase += StateCompleteToBase;
            StateSystem.Events.StateLevelRestart += StateLevelRestart;
            StateSystem.Events.StateLevelToZone += StateLevelToZone;
        }

        private void Start()
        {
            StateSystem.Data.StateDataAppLoading.CallBackExit = StateMainMenu;
            StateSystem.Events.StateEnter?.Invoke(StateSystem.Data.StateDataAppLoading);
        }

        private void StateMainMenu()
        {
            // StateSystem.Data.StateDataAppLoading.IsShow = false;
            // StateSystem.Events.StateEnter?.Invoke(StateSystem.Data.StateDataMainMenu);

            /*if (PlayerSystem.Data.CurrentPlayer.CurrentLevel <= 1)
            {
                StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataAppLoading, StateSystem.Data.StateDataZone);
            }
            else
            {
                StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataAppLoading, StateSystem.Data.StateDataMainMenu);
            }*/
        }
        
        private void StateSkills()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataMainMenu, StateSystem.Data.StateDataSkills);
        }

        private void StateSkillsBack()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataSkills, StateSystem.Data.StateDataMainMenu);
        }

        private void StateInventory()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataMainMenu, StateSystem.Data.StateDataInventory);
        }

        private void StateInventoryBack()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataInventory, StateSystem.Data.StateDataMainMenu);
        }

        private void StateMap()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataMainMenu, StateSystem.Data.StateDataMap);
        }

        private void StateMapBack()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataMap, StateSystem.Data.StateDataMainMenu);
        }

        private void StateZone(int index)
        {
            // FarmSystem.Events.SetCity?.Invoke(index);
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataMap, StateSystem.Data.StateDataMainMenu);
            // StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataMainMenu, StateSystem.Data.StateDataZone);
        }

        private void StateZoneBack()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataZone, StateSystem.Data.StateDataMap);
        }

        private void StateLevel()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataZone, StateSystem.Data.StateDataLevel);
        }
        
        private void StateCompleteToBase()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataLevel, StateSystem.Data.StateDataMainMenu);
        }

        private void StateLevelRestart()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataLevel, StateSystem.Data.StateDataLevel);
        }

        private void StateLevelToZone()
        {
            StateSystem.Events.StateEnterWithFade?.Invoke(StateSystem.Data.StateDataLevel, StateSystem.Data.StateDataZone);
        }

    }
}

