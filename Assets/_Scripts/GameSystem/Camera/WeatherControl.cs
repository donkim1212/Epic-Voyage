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
        new Color(253 / 255f, 156 / 255f, 203 / 255f),
        new Color(125 / 255f, 127 / 255f, 190 / 255f),
        new Color(193 / 255f, 130 / 255f, 76 / 255f)
    };

    void Awake() {
        // if (Application.platform == RuntimePlatform.Android) use_local_skybox = true;
        skybox = GetComponent<Skybox>();
        // RenderSettings.skybox = sb_materials[0];

        SetWeather(Weather.Midday);
        // DebugSystem.MountMessage((use_local_skybox + " / " + Weather.Midday), false);
    }

    void FixedUpdate() {
        if (use_local_skybox) {
            // skybox.transform.rotation = Quaternion.Euler(0f, degrees_per_sec * Time.time, 0f);
            skybox.material.SetFloat("_Rotation", degrees_per_sec * Time.time);
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