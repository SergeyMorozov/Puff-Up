using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GAME
{
    public class JoystickLogic : MonoBehaviour
    {
        private Camera _mainCamera;
        private RectTransform _canvas;
        private float _joystickSensitivity;

        private bool _swipe;
        private Vector3 _startTap;
        
        private void Awake()
        {
            _mainCamera = Camera.main;
            _canvas = UICanvas.Data.MainCanvas;
            _joystickSensitivity = _mainCamera.pixelWidth * JoystickSystem.Settings.SizeToScreen / 2;
        }

        private void Update()
        {
            JoystickData joystickData = JoystickSystem.Data;
            
            if (joystickData.IsLock)
            {
                joystickData.Direct = Vector3.zero;
                joystickData.Value = 0;
                return;
            }
            
            if (joystickData.BlockInput)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    joystickData.BlockInput = false;
                    joystickData.MousePressed = false;
                }
                return;
            }

            if (joystickData.JoystickWorldPoint != null)
                SetJoystickPosition(joystickData.JoystickWorldPoint);
                    
            if (Input.GetMouseButtonDown(0))
            {
                if (IsOverUI())
                {
                    joystickData.BlockInput = true;
                    return;
                }
                
                joystickData.MousePressed = true;
                _startTap = Input.mousePosition;
                
                JoystickSystem.Events.JoystickDown?.Invoke(_startTap);
                if(joystickData.BlockInput)
                    return;
                
                if (joystickData.JoystickWorldPoint == null)
                {
                    if (!JoystickSystem.Settings.IsStatic)
                    {
                        joystickData.JoystickPosition = Input.mousePosition;
                        joystickData.DirectValue = Vector3.zero;
                    }
                    else
                    {
                        float w = _mainCamera.pixelWidth;
                        float h = _mainCamera.pixelHeight;
                        Vector3 p = JoystickSystem.Settings.StaticViewPosition;
                        joystickData.JoystickPosition = new Vector3(w / 2 * (1 + p.x), h / 2 * (1 + p.y), 0);
                        joystickData.DirectValue =
                            (Input.mousePosition - joystickData.JoystickPosition) / _joystickSensitivity;
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                if (!_swipe)
                {
                    _swipe = (_startTap - Input.mousePosition).magnitude > 10;
                }
                
                joystickData.DirectValue =
                    (Input.mousePosition - joystickData.JoystickPosition) / _joystickSensitivity;

                joystickData.Direct = joystickData.DirectValue.normalized;
                joystickData.Value = joystickData.DirectValue.magnitude;
                joystickData.MousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (!_swipe)
                {
                    JoystickSystem.Events.JoystickTap?.Invoke(_startTap);
                }
                else
                {
                    Vector3 posUp = Input.mousePosition;
                    Vector3 swipeDirect = Vector3.zero;
                    if (Mathf.Abs(_startTap.x - posUp.x) > Mathf.Abs(_startTap.y - posUp.y) * 5)
                    {
                        // Left-Right
                        swipeDirect = _startTap.x - posUp.x > 0 ? Vector3.left : Vector3.right;
                    }
                    
                    if (Mathf.Abs(_startTap.y - posUp.y) > Mathf.Abs(_startTap.x - posUp.x) * 5)
                    {
                        // Up-Down
                        swipeDirect = _startTap.y - posUp.y > 0 ? Vector3.down : Vector3.up;
                    }

                    if (swipeDirect != Vector3.zero)
                    {
                        JoystickSystem.Events.JoystickSwipe?.Invoke(swipeDirect);
                    }
                }

                _swipe = false;
                joystickData.MousePressed = false;
                joystickData.Direct = Vector3.zero;
                joystickData.Value = 0;
            }
/*            
            TestPoint.anchoredPosition = joystickData.JoystickPosition -
                                         new Vector3(_mainCamera.pixelWidth / 2, _mainCamera.pixelHeight / 2, 0);
*/
        }

        private void SetJoystickPosition(Transform target)
        {
            JoystickData joystickData = JoystickSystem.Data;
            joystickData.JoystickPosition = GetPositionToScreen(target.position);
            joystickData.DirectValue =
                (Input.mousePosition - joystickData.JoystickPosition) / _joystickSensitivity;
        }

        private Vector2 GetPositionToScreen(Vector3 worldPoint)
        {
            Vector2 ViewportPosition = Camera.main.WorldToViewportPoint(worldPoint);
            Vector2 WorldObject_ScreenPosition = new Vector2(
                ViewportPosition.x * _canvas.sizeDelta.x - _canvas.sizeDelta.x * 0.5f + _mainCamera.pixelWidth / 2,
                ViewportPosition.y * _canvas.sizeDelta.y - _canvas.sizeDelta.y * 0.5f + _mainCamera.pixelHeight / 2);

            return WorldObject_ScreenPosition;
        }
        
        public static bool IsOverUI()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current);

#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR

		foreach (Touch touch in Input.touches)
		{
			pointerData.position = touch.position;
			if(CheckCanvas(pointerData))
			return true;
		}
		return false;

#endif

            pointerData.position = Input.mousePosition;
            return CheckCanvas(pointerData);
        }

        static bool CheckCanvas(PointerEventData pointerData)
        {
            if (EventSystem.current == null)
                return false;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count > 0)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].gameObject.GetComponent<CanvasRenderer>())
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}