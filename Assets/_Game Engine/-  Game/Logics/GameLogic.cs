using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace  GAME
{
    public class GameLogic : MonoBehaviour
    {
        private void Awake()
        {
            Random.InitState(0);
            
            Application.targetFrameRate = 1000;
            GameSystem.Data.GamePause = true;
            
            LoadingSystem.Events.AppLoadComplete += AppLoadComplete;
            
            // StoreGameSystem.Events.StoreDataLoaded += StoreDataLoaded;
            // LevelSystem.Events.LevelLoaded += LevelLoaded;
        }

        private void Start()
        {
            LoadingSystem.Events.AppLoad?.Invoke();
            
            // Загрузка предыдущих сохранённых данных
            // StoreGameSystem.Events.StoreDataLoad?.Invoke();
        }

        private void AppLoadComplete(Action actionOut)
        {
            GameSystem.Events.GameActionWithFade?.Invoke(actionOut, LevelSystem.Events.LevelLoad);
        }


        private void StoreDataLoaded()
        {
            // Загрузка текущего уровня, на основании загруженных данных
            // LevelsSystem.Events.LevelLoad?.Invoke();
            
//            CameraSystem.Events.SetZoom?.Invoke(30);
        }

        private void LevelLoaded()
        {
            LevelSystem.Data.TimeStart = Time.time;
            LevelSystem.Data.Progress = 0;
            LevelSystem.Data.IsWin = false;

            GameSystem.Data.GamePause = false;

            StoreGameSystem.Events.StoreDataSave?.Invoke();
            StartCoroutine(LevelStart());
        }

        private void LevelNext()
        {
            LevelSystem.Data.LevelNumber++;
            LevelRestart();
        }

        private void LevelRestart()
        {
            GameSystem.Data.GamePause = true;

            LevelSystem.Events.LevelLoad?.Invoke();
        }

        private void LevelComplete()
        {
            
        }

        private void LevelFail()
        {
            
        }

        IEnumerator LevelStart()
        {
            yield return new WaitForSeconds(0.1f);
            LevelSystem.Events.LevelStart?.Invoke();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (GameSystem.Data.GamePause != pauseStatus)
            {
                GameSystem.Data.GamePause = pauseStatus;
            }
        }

    }
}

