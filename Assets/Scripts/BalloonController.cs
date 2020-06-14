using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject Bullet;
    public bool active = true;
    public SphereCollider range;
    private Transform playerbody; 
    private float counter;
    private string state = "normal";
    private float reloadTime = 2f;
    private float bulletSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        playerbody = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(!active){return;}
        switch(state){
            case "In Range":
                counter -= Time.deltaTime; 
                if(counter <= 0f){
                    counter = reloadTime; 
                    Shoot();
                }
                break;
        }
    }

    public void SetGameStage(int stage){
        switch(stage){
            case 1:
                reloadTime = 1.5f;
                range.radius = 20f;
                bulletSpeed = 250f;
                break;
            case 2:
                reloadTime = 1.2f;
                range.radius = 22f;
                bulletSpeed = 300f;
                break;
            case 3:
                reloadTime = 1f;
                range.radius = 24f;
                bulletSpeed = 350f;
                break;
            case 4:
                reloadTime = 0.75f;
                range.radius = 26f;
                bulletSpeed = 400f;
                break;
            case 5:
                reloadTime = 0.5f;
                range.radius = 30f;
                bulletSpeed = 500f;
                break;
        }
    }

    private void Shoot(){
        var bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Vector3 dir = playerbody.position - transform.position; 
        dir.Normalize();
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpeed  * dir);
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
