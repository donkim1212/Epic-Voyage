using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Range (0, 23)]
    public static int hour;
    [Range (0, 5)]
    public static int minutes_in_ten;
    public const float game_hour_in_real_seconds = 10f;
    public const float game_10minute_in_real_seconds = game_hour_in_real_seconds / 6f;
    bool paused = false;

	void Awake () {
        // if loaded savegame, add some scripts
        hour = 17;
        // StartCoroutine(timeFlow());
    }
    
    IEnumerator timeFlow() {
        Debug.Log("entering timeFlow()...");
        while (!paused) {
            yield return new WaitForSecondsRealtime(game_10minute_in_real_seconds);
            minutes_in_ten += minutes_in_ten == 5 ? -5 : 1;
            if (minutes_in_ten == 0) {
                hour += hour == 23 ? -23 : 1;
            }
            Debug.Log("Current time: " + hour + ":" + minutes_in_ten * 10);
        }
    }

    public static float getTimeConversionConst() {
        return game_hour_in_real_seconds;
    }
}
