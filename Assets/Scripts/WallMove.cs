using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour
{
    [SerializeField] FloatReference posRef;
    float posCache;
    [SerializeField] FloatReference stepDistance;
    void Start()
    {
        posCache = posRef;
        Move();
    }
    private void OnEnable() {
        GetFrustum.OnAspectChange += Move;
    }
    private void OnDisable() {
        GetFrustum.OnAspectChange -= Move;
    }

    private void Move()
    {
        IEnumerator m()
        {
            while (transform.position != -posRef/2 * transform.forward)
            {
                transform.position = Vector3.MoveTowards(transform.position, -posRef/2 * transform.forward, stepDistance);
                yield return null;
            }
        }
        StartCoroutine(m());
    }
}
