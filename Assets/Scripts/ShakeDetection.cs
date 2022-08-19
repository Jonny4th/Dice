using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShakeDetection : MonoBehaviour
{
    public static event Action OnShake;
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
                OnShake?.Invoke();
                lastTriggerTime = Time.time;
            }
        }
    }
}
