using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessControl_DL : MonoBehaviour {

    //public Transform day_ref;
    //public Transform night_ref;

    private int time;
    private float conversion_const;

    private void Start() {
        conversion_const = TimeManager.getTimeConversionConst();
        updateTime();
    }

    private void FixedUpdate() {
        bool sunrise = time >= 6 && time <= 8;
        bool sunset = time >= 18 && time <= 20;
        if (sunrise) {
            // directional light rotation on x-axis from 90 to 0 (brighten)
            brightnessControl(true);
        }
        else if (sunset) {
            // directional light rotation on x-axis from 0 to 90 (darken)
            brightnessControl(false);
        }
        updateTime();
    }

    void updateTime() {
        time = TimeManager.hour;
    }

    void brightnessControl(bool brighten) {
        float sign = 1f;
        if (brighten) {
            sign = -1;
        }
        float x_rot = 90 * Time.fixedDeltaTime / (3 * conversion_const) * sign;
        Quaternion x_rotation = Quaternion.Euler(new Vector3(x_rot, 0f, 0f));
        transform.rotation *= x_rotation;
    }

    void colorControl(int dest_r, int dest_g, int dest_b) {
        // int cur_r;
        // int cur_g;
        // int cur_b;
    }
}
