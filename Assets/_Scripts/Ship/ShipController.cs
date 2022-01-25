using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private GameObject sp_d;
    [SerializeField]
    private GameObject player;
    private Vector3 move_vector = new Vector3(0.1f, 0, 0);

    void Awake() {
        player = sp_d.transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D)) {
            player.transform.position += move_vector;
        }
        else if (Input.GetKey(KeyCode.A)) {
            player.transform.position -= move_vector;
        }
    }
}
