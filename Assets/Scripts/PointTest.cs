using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTest : MonoBehaviour
{
    public Vector3 screenPoint;
    public Vector3 worldPoint;
    private void OnMouseDrag()
    {
        screenPoint = Input.mousePosition;
        screenPoint.z = Camera.main.transform.position.y;
        worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
    }
}
