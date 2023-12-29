using System;
using UnityEngine;

namespace  GAME
{
    public class CursorUILogic : MonoBehaviour
    {
        private RectTransform _mainCanvas;
        private CursorView _view;

        private bool _show;
        private Camera _camera;
        private float _startPositionLine;
        
        private void Awake()
        {
            _camera = GetComponentInParent<Canvas>().worldCamera;
            _mainCanvas = UICanvas.Data.MainCanvas;
        }

        private void Start()
        {
            Show();
        }

        private void Show()
        {
            _view = CursorUISystem.Instance.View;
            _view.Joystick.gameObject.SetActive(false);
            _view.gameObject.SetActive(true);
            
            _show = true;
        }

        private void Hide()
        {
            _show = false;

            _view.gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            if (!_show) return;

            if (Input.GetMouseButtonDown(0))
            {
                _view.Animator.SetBool("Press", true);
                _view.Animator.SetTrigger("Click");
//                _view.Joystick.position = _view.Cursor.position;
                _startPositionLine = _view.Joystick.anchoredPosition.x;
            }

/*
            if (Input.GetMouseButton(0))
            {
                _view.Joystick.gameObject.SetActive(true);
                DrawLine();
            }
            else
            {
                _view.Joystick.gameObject.SetActive(false);
            }
*/

            if (Input.GetMouseButtonUp(0))
            {
                _view.Animator.SetBool("Press", false);
            }

            // SetCursorPosition();
        }

        private void FixedUpdate()
        {
            SetCursorPosition();
        }

        private void SetCursorPosition()
        {
            Vector2 localpoint;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_mainCanvas, Input.mousePosition, _camera, out localpoint);
            _view.Cursor.anchoredPosition = localpoint;
        }

        private void DrawLine()
        {
            float scale = _view.Joystick.localScale.y;
            float delta = (_view.Cursor.anchoredPosition.x - _startPositionLine) /
                          scale / _view.JoystickLine.localScale.x;

            if (delta > 0)
            {
                _view.JoystickLine.sizeDelta = new Vector2(512 + delta, 512);
                _view.Joystick.localScale = new Vector3(scale, scale, 1);
            }
            else
            {
                _view.JoystickLine.sizeDelta = new Vector2(512 - delta, 512);
                _view.Joystick.localScale = new Vector3(-scale, scale, 1);
            }
        }

    }
}

