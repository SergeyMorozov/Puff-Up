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
                if(BallSystem.Data.CreatedBall != null) return;
                
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
                color.a = BallSystem.Settings.BallAlphaMove;
                ball.Ref.Sprite.color = color;
                ball.Ref.TextValue.alpha = BallSystem.Settings.TextAlphaMove;

                ball.Ref.Rigidbody.mass = BallSystem.Settings.BallMassMove;
                ball.Ref.Rigidbody.drag = BallSystem.Settings.BallDragMove;
                ball.Ref.Rigidbody.gravityScale = BallSystem.Settings.BallGravityMove;
                
                BallSystem.Data.CreatedBall = ball;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isCreate = false;

                BallObject ball = BallSystem.Data.CreatedBall;
                if(ball == null) return;
                
                Color color = ball.Ref.Sprite.color;
                color.a = BallSystem.Settings.BallAlphaFree;
                ball.Ref.Sprite.color = color;
                ball.Ref.Rigidbody.gravityScale = -1;
                ball.Ref.Rigidbody.mass = BallSystem.Settings.BallMassFree * ball.transform.localScale.x;
                ball.Ref.Rigidbody.drag = BallSystem.Settings.BallDragFree;
                ball.Ref.Rigidbody.gravityScale = BallSystem.Settings.BallGravityFree;
                ball.Ref.Collider.gameObject.layer = LayerMask.NameToLayer("Default");
                ball.transform.localScale = ball.LastScale * 0.95f;
                
                BallSystem.Data.CreatedBall = null;
            }
        }
        
    }
}

