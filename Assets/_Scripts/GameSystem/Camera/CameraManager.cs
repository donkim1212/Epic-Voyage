using System;
using UnityEngine;

// TODO: 
public class CameraManager : MonoBehaviour
{
    public Camera cam;
    public GameObject target;
    public int default_width = 1920;
    public int default_height = 1080;
    public bool maintain_width = true;
    // private float default_ratio;
    private float default_cam_height = 3.5f;
    private float default_cam_width;
    private float position_to_size_ratio = 3f / 3.5f;
    
    private float default_screen_ratio; // width / height
    private float y_offset = 0;
    private float mapWidth_halved;
    private float camWidth_halved;
    private float cam_max_x;

    void Start()
    {
        try {
            target = target.transform.GetChild(0).gameObject;
            Init();
            Rescale();
            mapWidth_halved = GameManager.GetMapWidth() / 2f;
            Debug.Log("mapWidth/2 = " + mapWidth_halved);
            camWidth_halved = default_cam_width / 2f;
            Debug.Log("camWidth/2 = " + camWidth_halved);
            cam_max_x = mapWidth_halved - camWidth_halved;
        } catch (Exception e) {
            Debug.Log(e.Message + e.StackTrace);
        }
    }

    void FixedUpdate() {
        // Recalculate();
        // Rescale();
        // Follow();
    }

    void Init() {
        if (cam == null) cam = GetComponent<Camera>();
        default_screen_ratio = (float) default_width / (float) default_height;
        // Debug.Log("ratio = " + default_screen_ratio);
        default_cam_width = default_cam_height * default_screen_ratio;
        // Debug.Log("screen_to_size_ratio = " + screen_to_size_ratio);
    }

    void Rescale() {
        y_offset = cam.orthographicSize * position_to_size_ratio;
        if (maintain_width) {
            cam.orthographicSize = default_cam_width / Camera.main.aspect;
            cam.transform.position = new Vector3(
                cam.transform.position.x,
                y_offset,
                cam.transform.position.z
            );
        }
    }

    void Follow() {
        // ValidateTargetPositionX();
        cam.transform.position = Vector3.Lerp(
            cam.transform.position,
            new Vector3(target.transform.position.x, target.transform.position.y + y_offset, cam.transform.position.z),
            2 * Time.deltaTime
        );
    }

    private float ValidateTargetPositionX(float x) {
        
        return x;
    }
    
}
