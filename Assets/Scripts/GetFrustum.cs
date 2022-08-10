using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFrustum : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float distance;
    [SerializeField] private FloatVariable frustumHeight;
    [SerializeField] private FloatVariable frustumWidth;
    
    void Start()
    {
        distance = _camera.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        frustumHeight.SetValue(Height(_camera, distance));
        frustumWidth.SetValue(Width(_camera, distance));
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
