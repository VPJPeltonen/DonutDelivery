using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public Material greenMat, yellowMat;
    private Renderer rend;
    private float count;
    private string state;
    private Vector3 scaleChange;
    
    void Start()
    {
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
                    state = "None";
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("playerdetected");
        if(other.tag == "Player"){
            state = "Activating";
            gameObject.GetComponent<MeshRenderer> ().material = yellowMat;
            gameObject.GetComponent<AudioSource>().Play();
            //Debug.Log("shoot");
            //Shoot();
        }
    }
}
