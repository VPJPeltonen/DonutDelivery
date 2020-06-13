using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    public Transform CameraTransform;
    Vector3 dir;

    void Update()    {
        dir.x = -CameraTransform.eulerAngles.y;
        transform.localEulerAngles = dir;
    }
}
