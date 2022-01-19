using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSelfRotation : MonoBehaviour {

    float RotationPerSecond = 1f;
    
	void Update () {
        float rot = RotationPerSecond * Time.deltaTime;
        Quaternion yRot = Quaternion.Euler(0f, rot, 0f);
        transform.rotation *= yRot;
    }
}
