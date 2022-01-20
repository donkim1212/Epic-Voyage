using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DebugSystem : MonoBehaviour
{
    public static Text text;
    private static StringBuilder sb = new StringBuilder();
    public GameObject player;
    // public Joystick left_stick;
    // public Joystick right_stick;
    
    void Awake() {
        text = GameObject.Find("Debug Overlay").GetComponent<Text>();
    }

    // void FixedUpdate() {
    //     try{
    //         // sb.AppendFormat("move: {0}\naim: {1}",
    //         //     left_stick.GetHorizontal(),
    //         //     right_stick.GetRotation()
    //         // );
    //         text.text = sb.ToString();
    //         sb.Clear();
    //     } catch (Exception e) {
    //         Debug.Log($"{e.Message + e.StackTrace}");
    //     }
    // }

    public static void MountMessage(string message, bool clear) {
        try {
            if (clear) sb.Clear();
            sb.Append(message);
            text.text = sb.ToString();
        } catch (Exception e) {
            Debug.Log(e.Message + e.StackTrace);
        }
        
    }
}
