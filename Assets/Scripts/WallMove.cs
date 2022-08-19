using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour
{
    [SerializeField] private FloatVariable posRef;
    private float posCache;
    [SerializeField] private float t;

    void Start()
    {
        posCache = posRef.Value;
        transform.position = -posCache/2 * transform.forward;
    }

    void FixedUpdate()
    {
        if (transform.position != -posRef.Value/2 * transform.forward)
        {
            transform.position = Vector3.Lerp(transform.position, -posRef.Value/2 * transform.forward, t);
        }
    }
}
