using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BallLogicCreate : MonoBehaviour
    {
        private Camera _camera;
        private int _layerCreateBall;

        private bool _isCreate;
        
        private void Awake()
        {
            _camera = Camera.main;
            _layerCreateBall = LayerMask.NameToLayer("CreateBall");
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
                BallObject ball = Tools.AddObject<BallObject>(BallSystem.Settings.Balls[0], null);
                ball.name = BallSystem.Settings.Balls[0].name;
                ball.transform.position = pos;
                ball.transform.localScale = Vector3.one * 0.1f;
                ball.Value = 1;
                ball.Colliders = new List<Collider2D>();
                ball.Ref.TextValue.text = ((int)ball.Value).ToString();

                Color color = ball.Ref.Sprite.color;
                color.a = BallSystem.Settings.BallAlpha;
                ball.Ref.Sprite.color = color;
                ball.Ref.TextValue.alpha = BallSystem.Settings.TextAlpha;

                BallSystem.Data.CreatedBall = ball;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isCreate = false;

                BallObject ball = BallSystem.Data.CreatedBall;
                Color color = ball.Ref.Sprite.color;
                color.a = 1;
                ball.Ref.Sprite.color = color;
                ball.Ref.Rigidbody.gravityScale = -1;
                
                BallSystem.Data.CreatedBall = null;
            }
        }
        
    }
}

