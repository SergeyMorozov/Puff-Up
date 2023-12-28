using System;
using UnityEngine;

namespace  GAME
{
    public class FadeUILogic : MonoBehaviour
    {
        private FadeView _view;
        private bool _show;
        
        private void Awake()
        {
            _view = FadeCanvas.Instance.View;
            _view.gameObject.SetActive(false);
            
            FadeCanvas.Instance.ShowFade += Show;
            FadeCanvas.Instance.HideFade += Hide;
        }

        private void Show()
        {
            if(_show) return;
            _show = true;
            _view.gameObject.SetActive(true);
            _view.CanvasGroup.blocksRaycasts = true;
        }

        private void Hide()
        {
            if(!_show) return;
            _show = false;
            _view.gameObject.SetActive(false);
            _view.CanvasGroup.blocksRaycasts = false;
        }

        private void Update()
        {
            if (GameSystem.Data.FadeShow && !_show) Show();
            if (!GameSystem.Data.FadeShow && _show) Hide();
            if(!_show) return;

            _view.CanvasGroup.alpha = GameSystem.Data.FadeValue;
        }

    }
}

