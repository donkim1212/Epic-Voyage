using System;
using UnityEngine;

public class SortingLayerController : MonoBehaviour
{
    private Renderer myRenderer;
    [Range(0, 7)]
    public int sortingLayer;
    
    private string[] arr = {
        "Default", "Background", "NonPlayer", "NonPlayerEffects",
        "Middle", "Player", "PlayerEffects", "Foreground"
    };
    void Awake() {
        myRenderer = GetComponent<Renderer>();
        myRenderer.sortingLayerName = arr[sortingLayer];
        // Debug.Log("sortingLayer = " + SortingLayer.GetLayerValueFromName(arr[sortingLayer]));
    }

    public void SetSortingLayer(int layerIndex) {
        try {
            myRenderer.sortingLayerName = arr[layerIndex];
        } catch (Exception e) {
            Debug.Log(e.Message + e.StackTrace);
        }
    }
}
