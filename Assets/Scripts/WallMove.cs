using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] private FloatVariable posRef;
    private float posCache;
    [Range(0.01f,1f)] [SerializeField] private float lerbT;
    [SerializeField] private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = posRef.Value/2 * direction;
        posCache = posRef.Value;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, 
                                                            posRef.Value/2 * direction, 
                                                            lerbT);
        posCache = posRef.Value;
    }
}
