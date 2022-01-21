using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float groundSize;

    private void Start()
    {
        var windowAspect = Screen.width / (float)Screen.height;
        var mainCamera = Camera.main;
        if (mainCamera == null) return;
        var size = groundSize / windowAspect;
        mainCamera.orthographicSize = size;
    }
}
