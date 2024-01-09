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
            _view.ButtonContinue.onClick.AddListener(OnClickLevelContinue);
            _view.ButtonRestart.onClick.AddListener(OnClickLevelRestart);

            _player = PlayerSystem.Data.CurrentPlayer;
            
            LevelSystem.Events.LevelComplete += LevelComplete;
            LevelSystem.Events.LevelFail += LevelFail;
            
            LevelSystem.Events.LevelNext += Hide;
            LevelSystem.Events.LevelRestart += Hide;
            LevelSystem.Events.LevelContinue += Hide;
            
        }

        private void LevelComplete()
        {
            Show();
            
            _view.PanelComplete.SetActive(true);
            _view.TextLevel.text = "Уровень " + LevelSystem.Data.LevelNumber;
        }

        private void LevelFail()
        {
            Show();
            
            _view.PanelFail.SetActive(true);
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
            _view.PanelFail.SetActive(false);
        }

        private void Update()
        {
            if(!_show) return;
            
        }

        private void OnClickLevelNext()
        {
            GameSystem.Events.GameActionWithFade?.Invoke(null, LevelSystem.Events.LevelNext);
        }
        
        private void OnClickLevelContinue()
        {
            LevelSystem.Events.LevelContinue?.Invoke();
        }

        private void OnClickLevelRestart()
        {
            GameSystem.Events.GameActionWithFade?.Invoke(null, LevelSystem.Events.LevelRestart);
        }

    }
}

