using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject Bullet;
    private Transform playerbody; 
    private float counter;
    private string state = "normal";
    // Start is called before the first frame update
    void Start()
    {
        playerbody = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case "In Range":
                counter -= Time.deltaTime; 
                if(counter <= 0f){
                    counter = 2f; 
                    Shoot();
                }
                break;
        }
    }

    private void Shoot(){
        var bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Vector3 dir = playerbody.position - transform.position; 
        dir.Normalize();
        bullet.GetComponent<Rigidbody>().AddForce(100f  * dir);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            state = "In Range";
            //Shoot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            state = "normal";
            //Shoot();
        }
    }    
}
