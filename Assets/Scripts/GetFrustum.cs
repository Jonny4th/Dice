using UnityEngine;
using System;

public class GetFrustum : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] float distance;
    [SerializeField] FloatVariable frustumHeight;
    [SerializeField] FloatVariable frustumWidth;
    [SerializeField] float screenRatio;
    public static event Action OnAspectChange;

    private void Awake() {
        distance = _camera.transform.position.y;
        screenRatio = _camera.aspect;
        frustumHeight.SetValue(Height(_camera, distance));
        frustumWidth.SetValue(Width(_camera, distance));
    }

    void Update()
    {
        if (screenRatio != _camera.aspect)
        {
            frustumHeight.SetValue(Height(_camera, distance));
            frustumWidth.SetValue(Width(_camera, distance));
            OnAspectChange?.Invoke();
            screenRatio = _camera.aspect;
        }
    }

    public float Height(Camera camera, float distance)
    {
        return 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
    }

    public float Width(Camera camera, float distance)
    {
        return Height(camera, distance) * camera.aspect;
    }
}
