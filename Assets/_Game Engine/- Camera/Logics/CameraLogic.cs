using UnityEngine;

namespace  GAME
{
    public class CameraLogic : MonoBehaviour
    {
        private CameraObject _camera;
        private Transform _cameraTarget;
        
        private void Awake()
        {
            _camera = CameraSystem.Data.CurrentCamera;
            _cameraTarget = CameraSystem.Data.CurrentCamera.Ref.CameraTarget;
            
            CameraSystem.Events.SetCameraPoint += SetCameraPoint;
            CameraSystem.Events.SetCameraTarget += SetCameraTarget;
        }

        private void SetCameraPoint(Vector3 point, bool smooth)
        {
            _camera.Cams[_camera.CamIndex].SetActive(false);
            if (smooth) Smooth();
            _camera.Cams[_camera.CamIndex].transform.position = point;
            _camera.Cams[_camera.CamIndex].SetActive(true);
        }

        private void SetCameraTarget(Transform obj, bool smooth)
        {
            _camera.Cams[_camera.CamIndex].SetActive(false);
            if (smooth) Smooth();
            _cameraTarget.SetParent(obj);
            _cameraTarget.localPosition = Vector3.zero;
            _camera.Cams[_camera.CamIndex].SetActive(true);
        }

        private void Smooth()
        {
            _camera.CamIndex++;
            if (_camera.CamIndex > 1) _camera.CamIndex = 0;
        }
    }
}

