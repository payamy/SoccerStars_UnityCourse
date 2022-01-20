using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float groundSize;

    private void Start()
    {
        //const float targetAspect = 16.0f / 9.0f;
        var windowAspect = Screen.width / (float)Screen.height;
        var mainCamera = Camera.main;
        if (mainCamera == null) return;
        var size = mainCamera.orthographicSize;
        //if (!(windowAspect < targetAspect)) return;
        var size1 = groundSize / windowAspect;
        mainCamera.orthographicSize = size1;
    }
}
