using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour
{
    [SerializeField] private FloatVariable posRef;
    private float posCache;
    [SerializeField] private float waitTime;

    void Start()
    {
        posCache = posRef.Value;
        transform.position = -posCache/2 * transform.forward;
    }

    void FixedUpdate()
    {
        if (posCache != posRef.Value)
        {
            StartCoroutine(Move(transform.position, -posRef.Value/2 * transform.forward));
        }
    }

    IEnumerator Move(Vector3 start, Vector3 destination)
    {
        posCache = posRef.Value;
        var t = 0f;
        while (t < waitTime)
        {
            transform.position = Vector3.Lerp(start, destination, t/waitTime);
            t += Time.deltaTime;
            if (t > waitTime) t = waitTime;
            yield return null;
        }
    }
}
