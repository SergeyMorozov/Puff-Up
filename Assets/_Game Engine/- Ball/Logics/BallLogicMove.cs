using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BallLogicMove : MonoBehaviour
    {
        private Camera _camera;
        private Plane _plane;
        private Vector3 _position;
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
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                
                float enter = 0.0f;
                if (!_plane.Raycast(ray, out enter)) return;
                _position = ray.GetPoint(enter);

                // Debug.Log(ball.Colliders.Count);

                Collider2D collider = Physics2D.OverlapCircle(ball.transform.position, ball.transform.localScale.x * 2.45f, _layerMask);

                if (collider != null)
                {
                    Vector3 direct = _position - ball.transform.position;
                    direct.Normalize();
                    ball.Ref.Rigidbody.AddForceAtPosition(direct * BallSystem.Settings.ForceMoving, _position, ForceMode2D.Impulse);
                }
                else
                {
                    ball.LastPosition = ball.transform.position;
                    ball.LastScale = ball.transform.localScale;
                    ball.LastValue = ball.Value;

                    ball.Ref.Rigidbody.MovePosition(Vector2.Lerp(ball.Ref.Rigidbody.position, _position, Time.deltaTime * 10));
                    ball.transform.localScale += Vector3.one * Time.deltaTime / 5f;
                }

                // Debug.Log("E-<");
                
                ball.Ref.TextValue.text = ((int)ball.Value).ToString();
            }
        }
    }
}

