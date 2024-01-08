using System;
using System.Collections;
using UnityEngine;

namespace  GAME
{
    public class LevelFinishUILogic : MonoBehaviour
    {
        private LevelFinishView _view;
        private bool _show;

        private PlayerObject _player;
        private LevelObject _level;
        
        private void Awake()
        {
            _view = LevelFinishCanvas.Instance.View;
            _view.PanelComplete.SetActive(false);
            _view.ButtonNext.onClick.AddListener(OnClickLevelNext);

            _player = PlayerSystem.Data.CurrentPlayer;
            
            LevelSystem.Events.LevelComplete += LevelComplete;
            LevelSystem.Events.LevelNext += LevelNext;
        }

        private void LevelComplete()
        {
            Show();
            
            _view.PanelComplete.SetActive(true);
            _view.TextLevel.text = "Уровень " + LevelSystem.Data.LevelNumber;
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            
            _view.PanelComplete.SetActive(false);
        }

        private void Update()
        {
            if(!_show) return;
            
        }

        private void OnClickLevelNext()
        {
            GameSystem.Events.GameActionWithFade?.Invoke(null, LevelSystem.Events.LevelNext);
        }
        
        private void LevelNext()
        {
            Hide();
        }

    }
}

