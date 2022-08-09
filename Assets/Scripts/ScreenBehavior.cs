using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehavior : MonoBehaviour
{
    public string screenOrientation;
    [SerializeField] private int width;
    [SerializeField] private int height;

    private void Start() {
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    void Update()
    {
        if (Screen.orientation == ScreenOrientation.Portrait
            || Screen.orientation == ScreenOrientation.PortraitUpsideDown) screenOrientation = "Portrait";
        else if (Screen.orientation == ScreenOrientation.LandscapeLeft
                 || Screen.orientation == ScreenOrientation.LandscapeLeft) screenOrientation = "Landscape";
        width = Screen.width;
        height = Screen.height;
    }
}
