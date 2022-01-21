using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera cam;
    public int default_width = 1920;
    public int default_height = 1080;
    public bool maintain_width = true;
    // private float default_ratio;
    private float default_cam_height = 3.5f;
    private float default_cam_width;
    private float screen_to_size_ratio = 3.5f / 5.4f;
    private float position_to_size_ratio = 3f / 3.5f;
    
    private float default_screen_ratio;
    private float new_cam_height;
    private float adapted_position;
    void Start()
    {
        Init();
        Rescale();
    }

    // void Update() {
    //     // Recalculate();
    //     Rescale();
    // }

    void Init() {
        if (cam == null) cam = GetComponent<Camera>();
        default_screen_ratio = (float) default_width / (float) default_height;
        Debug.Log("ratio = " + default_screen_ratio);
        default_cam_width = default_cam_height * default_screen_ratio;
        // new_cam_height = Screen.height / 100f / 2f * screen_to_size_ratio; // orthographicSize
        adapted_position = new_cam_height * position_to_size_ratio; // transform.position.y
        // Debug.Log("screen_to_size_ratio = " + screen_to_size_ratio);
    }

    void Rescale() {
        if (maintain_width) {
            cam.orthographicSize = default_cam_width / Camera.main.aspect;
            cam.transform.position = new Vector3(
                cam.transform.position.x,
                cam.orthographicSize * position_to_size_ratio,
                cam.transform.position.z
            );
        }
        
    }

    void Recalculate() {
        new_cam_height = default_cam_width / Camera.main.aspect; // orthographicSize
        adapted_position = new_cam_height * position_to_size_ratio; // transform.position.y
    }
}
