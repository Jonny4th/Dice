using UnityEngine;
using System.Collections;

public class WallMove : MonoBehaviour
{
    [SerializeField] private FloatVariable posRef;
    private float posCache;
    [SerializeField] private FloatVariable waitTime;

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
        var t = 0f;
        while (t < waitTime.Value)
        {
            transform.position = Vector3.Lerp(start, destination, t/waitTime.Value);
            t += Time.deltaTime;
            if (t > waitTime.Value) t = waitTime.Value;
            yield return null;
        }
        posCache = posRef.Value;
    }
}
