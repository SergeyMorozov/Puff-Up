using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace  GAME
{
    public class BallLogicCheckPlace : MonoBehaviour
    {
        private Camera _camera;
        private Plane _plane;
        private int _layerMask;
        private CheckPlace _checkPlace;

        private void Awake()
        {
            _camera = Camera.main;
            _plane = new Plane(Vector3.back, Vector3.zero);
            _layerMask = LayerMask.GetMask("Default") | LayerMask.GetMask("Chain");
            _checkPlace = BallSystem.Data.CheckPlace = new CheckPlace();
            
            BallSystem.Events.CheckFreePlace += CheckFreePlace;
            BallSystem.Events.CheckFreePlaceOnScreen += CheckFreePlaceOnScreen;
        }

        private CheckPlace CheckFreePlaceOnScreen(float radius)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                
            float enter = 0.0f;
            _plane.Raycast(ray, out enter);
            Vector3 position = ray.GetPoint(enter);

            return CheckFreePlace(position, radius);
        }

        private CheckPlace CheckFreePlace(Vector3 position, float radius)
        {
            Collider2D collider = Physics2D.OverlapCircle(position, radius, _layerMask);
            _checkPlace.IsFree = collider == null;
            _checkPlace.Position = position;
            _checkPlace.Radius = radius;
            return _checkPlace;
        }
    }

    [Serializable]
    public class CheckPlace
    {
        public bool IsFree;
        public Vector3 Position;
        public float Radius;
    }
}

