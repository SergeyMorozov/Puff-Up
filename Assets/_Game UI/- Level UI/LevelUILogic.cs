using System;
using System.Collections;
using UnityEngine;

namespace  GAME
{
    public class LevelUILogic : MonoBehaviour
    {
        private LevelView _view;
        private bool _show;

        private PlayerObject _player;
        private LevelObject _level;
        
        private void Awake()
        {
            _view = LevelCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            
            LevelSystem.Events.LevelLoaded += LevelLoaded;
            LevelCanvas.Instance.Show += Show;
            LevelCanvas.Instance.Hide += Hide;
        }

        private void LevelLoaded()
        {
            Show();
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);
            _view.MovesGroup.alpha = 0;

            _player = PlayerSystem.Data.CurrentPlayer;

            StartCoroutine(StartShow());
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            _view.gameObject.SetActive(false);
        }

        private void Update()
        {
            if(!_show) return;
            
            _view.TextMoney.text = ((int)_player.Money).ToString();
            _view.TextMoves.text = _player.Moves.ToString();
        }

        IEnumerator StartShow()
        {
            _view.AnimatorMoney.SetTrigger("Awake");
            _view.AnimatorMoves.SetTrigger("Awake");
            _view.AnimatorSound.SetTrigger("Awake");

            yield return new WaitForSeconds(0.2f);
            _view.AnimatorMoney.SetTrigger("Start");
            yield return new WaitForSeconds(0.1f);
            _view.AnimatorMoves.SetTrigger("Start");
            yield return new WaitForSeconds(0.1f);
            _view.AnimatorSound.SetTrigger("Start");
        }
        
        
    }
}

