using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherControl : MonoBehaviour
{
    public Light main_light;
    public Skybox skybox;
    public bool use_local_skybox = false;
    public float degrees_per_sec = 1f;
    public Material[] sb_materials = new Material[5];
    private Color[] light_color = {
        new Color(1f, 1f, 1f),
        new Color(155 / 255f, 155 / 255f, 155 / 255f),
        new Color(235 / 255f, 100 / 255f, 165 / 255f),
        new Color(102 / 255f, 108 / 255f, 231 / 255f),
        new Color(180 / 255f, 100 / 255f, 30 / 255f)
    };

    void Awake() {
        // if (Application.platform == RuntimePlatform.Android) use_local_skybox = true;
        skybox = GetComponent<Skybox>();
        SetWeather(Weather.Midday);
        DebugSystem.MountMessage((use_local_skybox + " / " + Weather.Midday), false);
        // RenderSettings.skybox = sb_materials[GameOptions.GetSkyboxTime()];
    }

    void FixedUpdate() {
        if (use_local_skybox) {
            skybox.transform.rotation = Quaternion.Euler(0f, degrees_per_sec * Time.time, 0f);
        }
        else {
            RenderSettings.skybox.SetFloat("_Rotation", degrees_per_sec * Time.time);
        }
        
    }

    public void SetWeather(int index) {
        try {
            if (use_local_skybox) {
                skybox.material = sb_materials[index];
            } else {
                RenderSettings.skybox = sb_materials[index];
            }
            main_light.color = light_color[index];
            // Debug.Log("main light color = " + main_light.color);
        } catch (Exception e) {
            DebugSystem.MountMessage((e.Message + e.StackTrace), false);
            Debug.Log(e.Message + e.StackTrace);
        }
    }

    public void SetWeather(Weather skyboxTime) {
        SetWeather((int) skyboxTime);
    }
}