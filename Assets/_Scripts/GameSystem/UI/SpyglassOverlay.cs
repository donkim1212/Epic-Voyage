using UnityEngine;

public class SpyglassOverlay : MonoBehaviour
{
    [SerializeField]
    private GameObject spyglass_overlay;
    private bool on = false;

    void Awake() {
        spyglass_overlay.SetActive(on);
    }

    // void FixedUpdate() {

    // }

    public void ToggleSpyglass () {
        if (on) on = false;
        else on =  true;
        spyglass_overlay.SetActive(on);
    }
}
