using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyScript : MonoBehaviour
{
    public Transform Center;
    public Rigidbody PlayerBody;
    public GameObject WindEffect;
    private bool playerInZone = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerInZone){
            Transform playerTF = PlayerBody.GetComponent<Transform>();
            Vector3 dir = Center.position - playerTF.position; 
            for(int i = 0; i < 3;i++){
                Vector3 windOffset = new Vector3(Random.Range(-3.0f, 3.0f),Random.Range(-3.0f, 3.0f),Random.Range(-3.0f, 3.0f));
                var windEffect = Instantiate(WindEffect, playerTF.position+windOffset, playerTF.rotation);
                windEffect.GetComponent<Rigidbody>().AddForce(dir*Random.Range(2.0f, 4.0f));
            }
            PlayerBody.AddForce(dir);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            playerInZone = false;
        }
    }
}
