using System;
using UnityEngine;

namespace  GAME
{
    public class GameLogicFade : MonoBehaviour
    {
        private bool _isShow;
        private Action _actionOut;
        private Action _actionIn;

        private void Awake()
        {
            GameSystem.Events.GameActionWithFade += GameActionWithFade;
        }

        private void GameActionWithFade(Action actionOut, Action actionIn)
        {
            _actionOut = actionOut;
            _actionIn = actionIn;

            GameSystem.Data.FadeShow = true;
            _isShow = true;
        }

        private void Update()
        {
            if (GameSystem.Data.FadeShow && _isShow)
            {
                GameSystem.Data.FadeValue += Time.deltaTime / GameSystem.Settings.FadeSpeed;
                if (GameSystem.Data.FadeValue >= 1)
                {
                    GameSystem.Data.FadeValue = 1;
                    _isShow = false;
                    
                    _actionOut?.Invoke();
                    _actionIn?.Invoke();
                }
            }
            
            if (GameSystem.Data.FadeShow && !_isShow)
            {
                GameSystem.Data.FadeValue -= Time.deltaTime / GameSystem.Settings.FadeSpeed;
                if (GameSystem.Data.FadeValue <= 0)
                {
                    GameSystem.Data.FadeValue = 0;
                    GameSystem.Data.FadeShow = false;
                }
            }

        }
    }
}

