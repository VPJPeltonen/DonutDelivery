using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    private float zRotation;
    private float stabilisingSpeed = 0.01f;
    private Rigidbody body;
    private UIScript UI;
    private int health = 6;
    void Start()
    {
        zRotation =  0f;
        body = gameObject.GetComponent<Rigidbody>();
        UI = GameObject.FindWithTag("UI").GetComponent<UIScript>();
    }

    void FixedUpdate()
    {
        move();
    }

    public void Damage(int damage){
        health -= damage;
        UI.UpdateHealth(health);
    }

    private void move(){
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

         
        if(Input.GetButton("Up")){
            body.AddForce ((speed/2)  * transform.up);
        }
        if(Input.GetButton("Down")){
            body.AddForce ((speed/2)  * -transform.up);
        }

        body.AddForce (yDir * speed  * transform.forward);
        body.AddForce (xDir * (speed/2)  * transform.right);
        Quaternion stableRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, stableRotation, Time.time * stabilisingSpeed);
    }
}
