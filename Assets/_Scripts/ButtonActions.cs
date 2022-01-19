using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour {

    public Button button1, button2, button3;

    void Start () {
        button1.onClick.AddListener(SpawnPlayerShip);
        button2.onClick.AddListener(SpawnEnemyShip);
    }
	
    void SpawnPlayerShip() {
        Debug.Log("Spawn Player Ship");
    }

    void SpawnEnemyShip() {
        Debug.Log("Spawn Enemy Ship");
    }

    void TestButtonClicked() {
        Debug.Log("Test Button Clicked!");
    }
}
