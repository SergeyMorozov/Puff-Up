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

            _player = PlayerSystem.Data.CurrentPlayer;
            
            LevelSystem.Events.LevelComplete += LevelComplete;
        }

        private void LevelComplete()
        {
            Show();
            
            _view.PanelComplete.SetActive(true);
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

        
    }
}

