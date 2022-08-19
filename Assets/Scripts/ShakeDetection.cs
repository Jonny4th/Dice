using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetection : MonoBehaviour
{
    public delegate void Shake();
    public static event Shake OnShake;
    [SerializeField] float shakeThreshold;
    [SerializeField] private float downTime;
    private float lastTriggerTime = 0;
    private float sqrMagnitude;

    void Update()
    {
        if (Time.time > lastTriggerTime + downTime)
        {
            if (Input.acceleration.sqrMagnitude > shakeThreshold)
            {
                OnShake();
                lastTriggerTime = Time.time;
            }
        }
    }
}
