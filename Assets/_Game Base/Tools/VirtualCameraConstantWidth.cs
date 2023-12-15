using Cinemachine;
using UnityEngine;

public class VirtualCameraConstantWidth : MonoBehaviour
{
    public Vector2 DefaultResolution = new Vector2(1080, 1920);
    [Range(0f, 1f)] public float WidthOrHeight = 0;

    private CinemachineVirtualCamera componentCamera;

    private float targetAspect;

    private float initialFov;
    private float horizontalFov = 120f;

    private void Start()
    {
        componentCamera = GetComponent<CinemachineVirtualCamera>();

        targetAspect = DefaultResolution.x / DefaultResolution.y;

        initialFov = componentCamera.m_Lens.FieldOfView;
        horizontalFov = CalcVerticalFov(initialFov, 1 / targetAspect);
    }

    private void Update()
    {
        float aspect = Screen.width / (float)Screen.height;
        float constantWidthFov = CalcVerticalFov(horizontalFov, aspect);
        componentCamera.m_Lens.FieldOfView = Mathf.Lerp(constantWidthFov, initialFov, WidthOrHeight);
    }

    private float CalcVerticalFov(float hFovInDeg, float aspectRatio)
    {
        float hFovInRads = hFovInDeg * Mathf.Deg2Rad;
        float vFovInRads = 2 * Mathf.Atan(Mathf.Tan(hFovInRads / 2) / aspectRatio);
        return vFovInRads * Mathf.Rad2Deg;
    }
}