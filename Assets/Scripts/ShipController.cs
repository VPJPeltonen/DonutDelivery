using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    private void move(){
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");

        Rigidbody body = gameObject.GetComponent<Rigidbody>();
        body.AddForce (yDir * speed  * transform.forward);
        body.AddForce (xDir * (speed/2)  * transform.right);

        /*
        Vector3 movement = transform.right * xDir + transform.forward * yDir;
        if (dashInput && dashStorage > 0f){
            controller.Move(movement * moveSpeed * dashPower * Time.deltaTime);
            dashStorage -= 20f * Time.deltaTime;
        }else{
            controller.Move(movement * moveSpeed * Time.deltaTime);
            if (dashStorage < 100){
                dashStorage += dashRegeneration * Time.deltaTime;
            }
        }
        bool onGround = checkHeight();
        if(onGround && xDir > 0 || yDir > 0 && onGround){
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(walk[Random.Range(0,walk.Length-1)],0.4f);
            }
        }*/
    }
}
