using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public GameObject Bullet;
    private Transform playerbody; 
    // Start is called before the first frame update
    void Start()
    {
        playerbody = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerbody);
    }

    private void Shoot(){
        var bullet = Instantiate(Bullet, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(100f  * transform.forward);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("playerdetected");
        if(other.tag == "Player"){
            Debug.Log("shoot");
            Shoot();
        }
    }
}
