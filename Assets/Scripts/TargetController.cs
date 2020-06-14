﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Material basicMat, activatingMat;
    public bool source = false;
    public Renderer mapRend;
    private Renderer rend;
    private float count;
    private string state;
    private Vector3 scaleChange, originalScale;
    private bool activeTarget = false;
    
    void Start()
    {
        originalScale = transform.localScale;
        rend = GetComponent<Renderer>();
        scaleChange = new Vector3(0.05f, 0.05f, 0.05f);
    }

    private void Update(){
        switch(state){
            case "Activating":
                count += Time.deltaTime;
                scaleChange = new Vector3(count, count, count);
                transform.localScale += scaleChange; 
                if (count >= 0.5f){
                    if(!source){
                        rend.enabled = false;
                        mapRend.enabled = false;
                    }
                    gameObject.GetComponent<MeshRenderer>().material = basicMat;
                    transform.localScale = originalScale;
                    count = 0f;
                    state = "None";
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            ShipController ship = other.GetComponent<ShipController>();
            if(ship.hasDonuts && source){
                return;
            }
            if(ship.hasDonuts && !source || !ship.hasDonuts && source){
                state = "Activating";
                ship.TargetTriggered(source);
                gameObject.GetComponent<MeshRenderer> ().material = activatingMat;
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
