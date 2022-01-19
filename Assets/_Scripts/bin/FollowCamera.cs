using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public Transform player;
    public Vector3 offset;
    public float speed;
    public bool lerp;
    float t;
    
    void Start () {
        transform.position = player.position + offset;

        // since t value is set in Start(), changing public field values
        // in-game would not change anything

        t = Time.fixedDeltaTime * speed;
        if (!lerp) {
            t = 1f;
        }
    }
    
    void FixedUpdate() {
        if (player != null) {
            Vector3 destination = player.transform.position + offset;
            transform.position = Vector3.Lerp(transform.position, destination, t);
            transform.LookAt(player.position, player.forward);
        }
    }
}
