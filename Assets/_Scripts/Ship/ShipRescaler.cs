using System;
using System.Collections.Generic;
using UnityEngine;

public class ShipRescaler : MonoBehaviour
{
    [Serializable]
    public enum RescaleTo {
        GrandParent, Parent, This, Root, Custom
    }
    public RescaleTo item = new RescaleTo();

    [SerializeField]
    private Vector3 new_scale = new Vector3(1f, 1f, 1f);
    [SerializeField]
    private GameObject collider_holder;
    [SerializeField]
    private GameObject particle_holder;
    
    void Awake() {
        if (item != RescaleTo.Custom) GetTargetScale();
        RescaleChildren();
    }

    void GetTargetScale() {
        try {
            if (item == RescaleTo.GrandParent) {
                new_scale = transform.parent.parent.localScale;
            }
            else if (item == RescaleTo.Parent) {
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
        } catch (Exception e) {
            Debug.Log(e.Message + e.StackTrace);
        }

    }

    void RescaleChildren() {
        SphereCollider[] cols = collider_holder.GetComponents<SphereCollider>();
        foreach(SphereCollider col in cols) {
            col.radius *= new_scale.y;
        }
        ParticleSystem[] ps = particle_holder.GetComponentsInChildren<ParticleSystem>();
        foreach(ParticleSystem p in ps) {
            p.transform.localScale = new_scale;
        }
    }
}
