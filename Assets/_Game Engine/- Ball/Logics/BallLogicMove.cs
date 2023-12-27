using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BallLogicMove : MonoBehaviour
    {
        private Camera _camera;
        private Plane _plane;
        private int _layerMask;

        private void Awake()
        {
            _camera = Camera.main;
            _plane = new Plane(Vector3.back, Vector3.zero);
            _layerMask = LayerMask.GetMask("Default") | LayerMask.GetMask("Chain");
        }

        private void FixedUpdate()
        {
            BallObject ball = BallSystem.Data.CreatedBall;

            if (ball != null && Input.GetMouseButton(0))
            {
                float radius = ball.Radius;
                float delta = Time.deltaTime * BallSystem.Settings.SpeedScale;
                
                CheckPlace checkPlaceBall = BallSystem.Events.CheckFreePlace?.Invoke(ball.transform.position, radius - delta * 2);
                bool isFree = checkPlaceBall.IsFree;
                CheckPlace checkPlaceMouse = BallSystem.Events.CheckFreePlaceOnScreen?.Invoke(radius);

                if (isFree)
                {
                    ball.LastPosition = ball.transform.position;
                    ball.LastScale = ball.transform.localScale;
                    ball.LastValue = ball.Value;

                    ball.Ref.Rigidbody.MovePosition(Vector2.Lerp(ball.transform.position, checkPlaceMouse.Position, Time.deltaTime * 10));
                    ball.Radius += delta;
                    ball.transform.localScale = Vector3.one * ball.Radius * 2;
                    
                    ball.Value += Time.deltaTime * BallSystem.Settings.SpeedValue;
                }
                else
                {
                    Vector3 direct = checkPlaceMouse.Position - ball.transform.position;
                    direct.Normalize();
                    ball.Ref.Rigidbody.AddForceAtPosition(direct * BallSystem.Settings.ForceMoving, checkPlaceMouse.Position, ForceMode2D.Impulse);
                }
                
                ball.Ref.TextValue.text = ((int)ball.Value).ToString();
            }
        }
    }
}

