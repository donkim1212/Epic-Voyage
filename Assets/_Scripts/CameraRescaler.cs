using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRescaler : MonoBehaviour
{
    public int default_width = 1920;
    public int default_height = 1080;
    private float default_ratio;
    private float default_cam_height = 3.5f;
    void Awake()
    {
        default_ratio = default_width / default_height;
        float current_ratio = Screen.width / Screen.height;
        // Camera.main.orthographicSize = 
    }
}
