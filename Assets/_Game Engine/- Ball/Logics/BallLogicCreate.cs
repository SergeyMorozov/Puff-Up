using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BallLogicCreate : MonoBehaviour
    {
        private Camera _camera;
        private int _layerCreateBall;
        private Plane _plane;

        private bool _isCreate;
        private BallObject _ball;
        
        private void Awake()
        {
            _camera = Camera.main;
            _layerCreateBall = LayerMask.NameToLayer("CreateBall");
            _plane = new Plane(Vector3.back, Vector3.zero);
        }

        private void Update()
        {
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (!Physics.Raycast(ray, out hit, 100, _layerCreateBall)) return;

                _isCreate = true;
                Vector3 pos = hit.point;
                pos.z = 0;
                _ball = Tools.AddObject<BallObject>(BallSystem.Settings.Balls[0], null);
                _ball.name = BallSystem.Settings.Balls[0].name;
                _ball.transform.position = pos;
                _ball.transform.localScale = Vector3.one * 0.1f;
                _ball.Value = 1;
                _ball.Collisions = new List<Collision>();
                _ball.Ref.TextValue.text = ((int)_ball.Value).ToString();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isCreate = false;
                _ball = null;
            }
        }
        
        private void FixedUpdate()
        {
            if (_isCreate && Input.GetMouseButton(0))
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                
                float enter = 0.0f;
                if (!_plane.Raycast(ray, out enter)) return;
                Vector2 pos = ray.GetPoint(enter);

                _ball.Ref.Rigidbody.MovePosition(pos);
                _ball.transform.localScale += Vector3.one * Time.deltaTime / 5f;
                _ball.Value += _ball.Value * Time.deltaTime * 1.2f;
                _ball.Ref.TextValue.text = ((int)_ball.Value).ToString();
            }
        }
    }
}

