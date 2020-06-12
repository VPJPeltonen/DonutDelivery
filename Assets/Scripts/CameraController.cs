using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target,ship, targetPosition;
    protected Quaternion stableRotation;
    protected float cameraSpeed = 0.005f;
    void Start(){

        stableRotation = transform.rotation;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.time * cameraSpeed);
        transform.LookAt(target);
        transform.rotation = ship.rotation;
        //transform.rotation = stableRotation;
    }

}
