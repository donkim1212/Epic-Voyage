using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControlOld : MonoBehaviour {

    public enum WeatherOld {
        midday, evening, sunset, midnight, midnight_moon, midnight_darker, daybreak
    }
    
    [Header("Weather Controller")]
    public WeatherOld chooseWeatherName;
    private WeatherOld tempName;

    [Space(25)]

    [Header("Light Properties")]
    public Light lit;
    public bool useCustomColor = false;
    public Color midday;
    public Color evening;
    public Color sunset;
    public Color midnight;
    public Color midnight_moon;
    public Color midnight_darker;
    public Color daybreak;

    [Header("Skybox Properties")]
    public Camera skyboxCam;
    public List<Material> materials;
    private Skybox skybox;

    private void Start() {
        // lit = GetComponent<Light>();
        // IMPORTANT: color should be normalized (ranges from 0 to 1f, where 1f is white)
        if (!useCustomColor) {
            midday = new Color(1f, 1f, 1f);
            evening = new Color(155 / 255f, 155 / 255f, 155 / 255f);
            sunset = new Color(235 / 255f, 100 / 255f, 165 / 255f);
            midnight = new Color(102 / 255f, 108 / 255f, 231 / 255f);
            midnight_moon = new Color(54 / 255f, 54 / 255f, 32 / 255f);
            midnight_darker = new Color(0 / 255f, 0 / 255f, 0 / 255f);
            daybreak = new Color(180 / 255f, 100 / 255f, 30 / 255f);
        }
        skybox = skyboxCam.GetComponent<Skybox>();
        tempName = chooseWeatherName;
    }

    private void Update() {
        /*if (!tempName.Equals(chooseWeatherName)) {
            UpdateWeather();
            tempName = chooseWeatherName;
            Debug.Log("Changing weather... Job done.");
        }*/
        UpdateWeather();
    }

    private void UpdateWeather() {
        // Color tempColor = lit.color;

        switch (chooseWeatherName) {
            case WeatherOld.midday:
                lit.color = midday;
                ChooseSkybox(0);
                break;
            case WeatherOld.evening:
                lit.color = evening;
                ChooseSkybox(1);
                break;
            case WeatherOld.sunset:
                lit.color = sunset;
                ChooseSkybox(2);
                break;
            case WeatherOld.midnight:
                lit.color = midnight;
                ChooseSkybox(3);
                break;
            case WeatherOld.midnight_moon:
                lit.color = midnight_moon;
                ChooseSkybox(4);
                break;
            case WeatherOld.midnight_darker:
                lit.color = midnight_darker;
                ChooseSkybox(5);
                break;
            case WeatherOld.daybreak:
                lit.color = daybreak;
                ChooseSkybox(6);
                break;
            default:
                // lit.color = tempColor;
                break;
        }
        
        // Debug.Log("R:" + lit.color.r + " G:" + lit.color.g + " B:" + lit.color.b);
    }

    private void ChooseSkybox(int index) {
        skybox.material = materials[index];
    }
}
