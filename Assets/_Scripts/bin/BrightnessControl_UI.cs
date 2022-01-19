using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl_UI : MonoBehaviour {
    
    [Range (0f, max_alpha)]
    public float alpha;
    const float max_alpha = 220f / 255f;

    public Image image;
    // public bool coroutineActive = false;

    private int time;
    private float conversion_const;

    private void Start() {
        image = gameObject.GetComponent<Image>();
        conversion_const = TimeManager.getTimeConversionConst();
        updateAlpha();
        updateTime();
    }

    private void FixedUpdate() {
        updateTime();
        // if (!coroutineActive) {
            // brigtness changes over 3 in-game hours
            if (time >= 6 && time <= 8) {
            // coroutineActive = true;
            // StartCoroutine(perSecondAction(true));
            changeAlphaValue(true);
            }
            else if (time >= 18 && time <= 20) {
            // coroutineActive = true;
            // StartCoroutine(perSecondAction(false));
            changeAlphaValue(false);
            }
        // }
        //else if (coroutineActive) {
        //    if (time != 6 && time != 18) {
        //        coroutineActive = false;
        //    }
        //}
        updateAlpha();
    }

    void updateAlpha() {
        var tempColor = image.color;
        tempColor.a = alpha;
        image.color = tempColor;
    }

    void updateTime() {
        time = TimeManager.hour;
    }

    void changeAlphaValue(bool brighten) {
        float sign = 1f;
        if (brighten) {
            sign = -1f;
        }
        alpha += (max_alpha * Time.fixedDeltaTime / (3 * conversion_const)) * sign;
    }

    //IEnumerator perSecondAction(bool brighten) {
    //    float sign = 1f;
    //    if (brighten)
    //        sign = -1f;
    //    alpha += (max_alpha * Time.fixedDeltaTime / (3 * conversion_const)) * sign;
    //    yield return new WaitForFixedUpdate();
    //    coroutineActive = false;
    //}
}
