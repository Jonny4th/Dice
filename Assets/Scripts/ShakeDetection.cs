using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetection : MonoBehaviour
{
    public delegate void Shake();
    public static event Shake OnShake;
    [SerializeField] float shakeThreshold;
    private float sqrMagnitude;

    void Update()
    {
        if (Input.acceleration.sqrMagnitude > shakeThreshold) OnShake();
    }
}
