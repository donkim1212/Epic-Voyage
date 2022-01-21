using System;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRescaler : MonoBehaviour
{
    [Serializable]
    public enum RescaleTo {
        Parent, This, Root, Custom
    }
    public RescaleTo item = new RescaleTo();

    [SerializeField]
    private Vector3 new_scale = new Vector3(1f, 1f, 1f);
    
    void Awake() {
        if (item != RescaleTo.Custom) GetTargetScale();
        RescaleChildren();
    }

    void GetTargetScale() {
        if (item == RescaleTo.Parent) {
            new_scale = transform.parent.localScale;
        }
        else if (item == RescaleTo.This) {
            new_scale = transform.localScale;
        }
        else if (item == RescaleTo.Root) {
            Transform temp = transform;
            while (temp.parent != null) {
                temp = temp.parent;
            }
            new_scale = temp.transform.localScale;
        }
    }

    void RescaleChildren() {
        ParticleSystem[] ps = gameObject.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem p in ps) {
            p.transform.localScale = new_scale;
        }
    }
}
