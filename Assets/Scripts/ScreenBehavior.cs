using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehavior : MonoBehaviour
{
    public ScreenOrientation orientation;
    [SerializeField] private int width;
    [SerializeField] private int height;

    private void Start() {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    void Update()
    {
        orientation = Screen.orientation;
        width = Screen.width;
        height = Screen.height;
    }
}
