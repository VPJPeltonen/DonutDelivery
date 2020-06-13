using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Material greenMat, yellowMat;
    public Renderer mapRend;
    private Renderer rend;
    private float count;
    private string state;
    private Vector3 scaleChange, originalScale;
    private bool source = false;
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
                transform.localScale += scaleChange; 
                if (count >= 0.5f){
                    rend.enabled = false;
                    mapRend.enabled = false;
                    state = "None";
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            state = "Activating";
            other.GetComponent<ShipController>().TargetTriggered(source);
            gameObject.GetComponent<MeshRenderer> ().material = yellowMat;
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
