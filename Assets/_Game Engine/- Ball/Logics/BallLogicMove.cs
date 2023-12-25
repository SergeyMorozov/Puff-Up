using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BallLogicMove : MonoBehaviour
    {
        private Camera _camera;
        private Plane _plane;
        private Vector3 _position;

        private void Awake()
        {
            _camera = Camera.main;
            _plane = new Plane(Vector3.back, Vector3.zero);
        }

        private void FixedUpdate()
        {
            BallObject ball = BallSystem.Data.CreatedBall;

            if (ball != null && Input.GetMouseButton(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                
                float enter = 0.0f;
                if (!_plane.Raycast(ray, out enter)) return;
                _position = ray.GetPoint(enter);

                // Debug.Log(ball.Colliders.Count);
                
                if (ball.Colliders.Count <= 0)
                {
                    ball.LastPosition = ball.transform.position;
                    ball.LastScale = ball.transform.localScale;
                    ball.LastValue = ball.Value;

                    // Vector3 direct = pos - ball.transform.position;
                    // ball.Ref.Rigidbody.AddForceAtPosition(direct * BallSystem.Settings.ForceMoving, pos, ForceMode2D.Force);
                    ball.Ref.Rigidbody.MovePosition(Vector2.Lerp(ball.Ref.Rigidbody.position, _position, Time.deltaTime * 10));
                    ball.transform.localScale += Vector3.one * Time.deltaTime / 15f;
                    // ball.Value += ball.Value * Time.deltaTime * 1.2f;
                }
                else
                {
                    Vector3 direct = _position - ball.transform.position;
                    direct.Normalize();
                    ball.Ref.Rigidbody.AddForceAtPosition(direct * BallSystem.Settings.ForceMoving, _position, ForceMode2D.Impulse);
                    // ball.transform.localScale += Vector3.one * Time.deltaTime / 5f;
                    // ball.Value += ball.Value * Time.deltaTime * 1.2f;
                    // ball.transform.position = ball.LastPosition;
                    // ball.transform.localScale = ball.LastScale;
                    // ball.Value = ball.LastValue;
                    // ball.Ref.Rigidbody.MovePosition(ball.transform.position);
                }

                // Debug.Log("E-<");
                
                ball.Ref.TextValue.text = ((int)ball.Value).ToString();
            }
        }
    }
}

