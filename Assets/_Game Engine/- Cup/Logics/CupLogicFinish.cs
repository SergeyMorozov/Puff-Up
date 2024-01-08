using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  GAME
{
    public class CupLogicFinish : MonoBehaviour
    {
        private float _timerRemoveShapes;
        private List<Transform> _shapes;
        
        private void Awake()
        {
            _shapes = new List<Transform>();
            
            ChainSystem.Events.ChainDestroy += ChainDestroy;
        }

        private void ChainDestroy(ChainObject chain)
        {
            _shapes.Clear();
            foreach (ShapeObject shape in CupSystem.Data.CurrentCup.Shapes)
            {
                _shapes.Add(shape.transform);
            }

            foreach (BallObject ball in BallSystem.Data.Balls)
            {
                ball.Ref.Rigidbody.gravityScale = -0.1f;
                // _shapes.Add(ball.transform);
            }
            
            _timerRemoveShapes = 1;
            
            if (CupSystem.Data.Index >= CupSystem.Data.Cups.Count - 1)
            {
                LevelSystem.Events.LevelFinish?.Invoke();
                return;
            }

            LevelSystem.Events.NextCup?.Invoke();
            StartCoroutine(ShowShapeNextCup());
        }

        IEnumerator ShowShapeNextCup()
        {
            yield return new WaitForSeconds(2);

            foreach (ShapeObject shape in CupSystem.Data.CurrentCup.Shapes)
            {
                shape.gameObject.SetActive(true);
            }
            CupSystem.Data.CurrentCup.Ref.BorderBottom.gameObject.SetActive(true);
            
            float time = 0;
            while (time < 1)
            {
                time += Time.deltaTime;
                if (time > 1) time = 1;
                
                foreach (ShapeObject shape in CupSystem.Data.CurrentCup.Shapes)
                {
                    shape.transform.localScale = new Vector3(time, time, 1);
                }

                CupSystem.Data.CurrentCup.Ref.BorderBottom.localScale = new Vector3(1, time, 1);
                yield return null;
            }
        }

        private void Update()
        {
            if (_timerRemoveShapes <= 0) return;

            _timerRemoveShapes -= Time.deltaTime / 2;
            if (_timerRemoveShapes <= 0)
            {
                _timerRemoveShapes = 0;
                
                foreach (BallObject ball in BallSystem.Data.Balls)
                {
                    Destroy(ball.gameObject);
                }
                BallSystem.Data.Balls.Clear();
            }
            
            foreach (BallObject ball in BallSystem.Data.Balls)
            {
                ball.transform.localScale = Vector3.one * ball.Radius * 2 * _timerRemoveShapes;
            }
         
            foreach (Transform shape in _shapes)
            {
                shape.localScale = new Vector3(_timerRemoveShapes, _timerRemoveShapes, 1);
            }
        }
    }
}

