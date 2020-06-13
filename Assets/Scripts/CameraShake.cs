using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private bool shaking = false;
    private Vector3 normalPos;
    private float shakeCounter,shakeMagnitude;

    void Start(){
        normalPos = transform.localPosition;
    }

    void Update()
    {
        if(shaking){
            float xOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            float yOffset = Random.Range(-shakeMagnitude, shakeMagnitude);
            transform.localPosition = new Vector3(transform.localPosition.x+xOffset,transform.localPosition.y+yOffset,transform.localPosition.z);
            shakeCounter -= Time.deltaTime;
            if (shakeCounter < 0f){
                shaking = false;
                transform.localPosition = normalPos;
            }
        }
    }

    public void StartShake(float mag){
        shaking = true;
        shakeCounter = 0.3f;
        shakeMagnitude = mag;
    }
}
