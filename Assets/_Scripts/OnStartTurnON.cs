using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartTurnON : MonoBehaviour {

    public List<GameObject> array;

	// Use this for initialization
	void Start () {
        foreach (var item in array) {
            item.SetActive(true);
        }
        
	}
	
}
