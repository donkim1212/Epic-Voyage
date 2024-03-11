using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static MeshRenderer mapRef;
    void Awake() {
        /// On Awake(), load settings from saved location
        // File settings = LoadSettings();
        // Weather weather = (Weather) settings.read(); // int
        // WeatherControl.SetWeather(weather);
        try {
            mapRef = GameObject.Find("Wave - Player Layer").GetComponent<MeshRenderer>();
        } catch (Exception e) {
            Debug.Log(e.Message + e.StackTrace);
        }
    }

    public static float GetMapWidth() {
        if (mapRef != null) {
            return mapRef.bounds.size.x;
        }
        else {
            throw new Exception("GameManager: mapRef is Null.");
        }
    }
}
