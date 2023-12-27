using System;
using UnityEngine;

namespace  GAME
{
    public class BallLogicCollision : MonoBehaviour
    {
        private int _layerTrigger;
        
        private void Awake()
        {
            _layerTrigger = LayerMask.NameToLayer("Trigger");
            
            BallSystem.Events.BallColliderEnter += BallColliderEnter;
            BallSystem.Events.BallColliderExit += BallColliderExit;
            BallSystem.Events.BallCreated += BallCreated;
        }

        private void BallColliderEnter(BallObject ball, Collider2D collider)
        {
            if (collider.gameObject.layer != _layerTrigger ||
                ball.CollidersChain.Contains(collider) ||
                ball.CollidersBalls.Contains(collider)) return;
            
            // Debug.Log("+++ " + other.name);

            ChainObject chain = collider.gameObject.GetComponentInParent<ChainObject>();
            if (chain != null)
            {
                ball.CollidersChain.Add(collider);
                RecalculateConnects();
                return;
            }

            BallObject ballCollision = collider.gameObject.GetComponentInParent<BallObject>();
            if (ballCollision != null)
            {
                ball.CollidersBalls.Add(collider);
                ball.ConnectedBalls.Add(ballCollision);
                RecalculateConnects();
            }
        }
        
        private void BallColliderExit(BallObject ball, Collider2D collider)
        {
            if(collider.gameObject.layer != _layerTrigger) return;
            if (!ball.CollidersChain.Contains(collider) &&
                !ball.CollidersBalls.Contains(collider)) return;
            
            // Debug.Log("------ " + other.name);

            ChainObject chain = collider.gameObject.GetComponentInParent<ChainObject>();
            if (chain != null)
            {
                ball.CollidersChain.Remove(collider);
                RecalculateConnects();
                return;
            }

            BallObject ballCollider = collider.gameObject.GetComponentInParent<BallObject>();
            if (ballCollider != null)
            {
                ball.CollidersBalls.Remove(collider);
                ball.ConnectedBalls.Remove(ballCollider);
                RecalculateConnects();
            }
        }

        private void BallCreated(BallObject ball)
        {
            RecalculateConnects();
        }

        private void RecalculateConnects()
        {
            foreach (BallObject ball in BallSystem.Data.Balls)
            {
                ball.IsChainConnected = false;
            }
            
            foreach (BallObject ball in BallSystem.Data.Balls)
            {
                if(ball.CollidersChain.Count == 0) continue;
                ConnectToChain(ball);
            }
        }

        private void ConnectToChain(BallObject ball)
        {
            ball.IsChainConnected = true;

            if (ball.Value > 0)
            {
                BallSystem.Events.BallConnected?.Invoke(ball);
                ball.Value = 0;
            }
            
            foreach (BallObject ballConnected in ball.ConnectedBalls)
            {
                if(ballConnected.IsChainConnected) continue;
                ConnectToChain(ballConnected);
            }
        }

        private void Update()
        {
            foreach (BallObject ball in BallSystem.Data.Balls)
            {
                ball.Ref.Outline.SetActive(!ball.IsChainConnected);
            }
        }
    }
}

