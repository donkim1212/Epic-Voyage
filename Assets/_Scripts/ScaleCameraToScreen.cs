using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleCameraToScreen : MonoBehaviour {
    public bool maintainWidth = true;
    [Range(-1,1)]
    public int adaptPosition;

    float defaultWidth;
    float defaultHeight;

    Vector3 cameraPos;
    float offset;

    private void Start() {
        cameraPos = Camera.main.transform.position;
        offset = Camera.main.transform.position.y;
        defaultHeight = Camera.main.orthographicSize;
        defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
        Debug.Log("Default w / h = " + defaultWidth + " / " + defaultHeight);
    }

    private void Update() {
        if (maintainWidth) {
            Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
            Camera.main.transform.position
                = new Vector3(cameraPos.x, offset + adaptPosition * (defaultHeight - Camera.main.orthographicSize), cameraPos.z);
        }
        else {
            Camera.main.transform.position
                = new Vector3(adaptPosition * (defaultWidth - Camera.main.orthographicSize * Camera.main.aspect), cameraPos.y, cameraPos.z);
        }
    }
}
