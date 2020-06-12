using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingReticle : MonoBehaviour
{
    private GameObject mainUI;
    public Transform tracker;   
    public Camera cam;
    void Start(){
        mainUI = GameObject.FindWithTag("UI");
        transform.parent = mainUI.transform;
    }

    void Update(){
        Vector3 pos = cam.WorldToScreenPoint(tracker.position);
        transform.position = pos;
    }
}
