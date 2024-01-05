using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class BallLogicCreate : MonoBehaviour
    {
        private Camera _camera;
        private int _layerCreateBall;
        private Plane _plane;
        private Vector3 _position;
        private bool _isCreate;
        private PlayerObject _player;

        private void Awake()
        {
            _camera = Camera.main;
            _layerCreateBall = LayerMask.NameToLayer("CreateBall");
            _plane = new Plane(Vector3.back, Vector3.zero);
            _player = PlayerSystem.Data.CurrentPlayer;
        }

        private void Update()
        {
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                if(BallSystem.Data.CreatedBall != null) return;

                CheckPlace checkPlace = BallSystem.Events.CheckFreePlaceOnScreen?.Invoke(BallSystem.Settings.MinRadius * 1.05f);
                if(!checkPlace.IsFree) return;

                _isCreate = true;
                BallObject ball = Tools.AddObject<BallObject>(BallSystem.Settings.Balls[0], null);
                ball.name = BallSystem.Settings.Balls[0].name;
                ball.transform.position = checkPlace.Position;
                ball.ValueMax = 1;
                ball.Radius = BallSystem.Settings.MinRadius;
                ball.transform.localScale = Vector3.one * ball.Radius * 2;
                ball.CollidersBalls = new List<Collider2D>();
                ball.Ref.TextValue.text = ((int)ball.ValueMax).ToString();

                Color color = ball.Ref.Sprite.color;
                color.a = BallSystem.Settings.BallAlphaMove;
                ball.Ref.Sprite.color = color;
                ball.Ref.TextValue.alpha = BallSystem.Settings.TextAlphaMove;

                ball.Ref.Rigidbody.mass = BallSystem.Settings.BallMassMove;
                ball.Ref.Rigidbody.drag = BallSystem.Settings.BallDragMove;
                ball.Ref.Rigidbody.gravityScale = 0;
                
                BallSystem.Data.CreatedBall = ball;
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isCreate = false;

                BallObject ball = BallSystem.Data.CreatedBall;
                if(ball == null) return;

                ball.Value = ball.ValueMax;
                Color color = ball.Ref.Sprite.color;
                color.a = BallSystem.Settings.BallAlphaFree;
                ball.Ref.Sprite.color = color;
                ball.Ref.Rigidbody.gravityScale = -1;
                ball.Ref.Rigidbody.mass = BallSystem.Settings.BallMassFree * ball.transform.localScale.x;
                ball.Ref.Rigidbody.drag = BallSystem.Settings.BallDragFree;
                ball.Ref.Rigidbody.gravityScale = BallSystem.Settings.BallGravityFree;
                ball.Ref.Collider.gameObject.layer = LayerMask.NameToLayer("Default");
                ball.Ref.Trigger.enabled = true;
                ball.transform.localScale *= 0.95f;
                BallSystem.Data.Balls.Add(ball);

                _player.Money += ball.Value;
                
                BallSystem.Data.CreatedBall = null;
                BallSystem.Events.BallCreated?.Invoke(ball);
            }
        }
        
    }
}

