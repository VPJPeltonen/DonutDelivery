﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSens = 50f;
    public Transform playerBody;
    public float turnSpeed = 2f; 
    private float xRot = 0f;
    private string state;
    void Start(){
        
    }

    void FixedUpdate(){
        switch(state){
            case "normal":
                float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
                transform.Rotate(Vector3.up * mouseX * turnSpeed);
                transform.Rotate(Vector3.right * mouseY * turnSpeed);
                break;
        }

    }

    public void GameOver(){
        state = "dead";
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartGame(){
        Cursor.lockState = CursorLockMode.Locked;
        state = "normal";
    }

}
