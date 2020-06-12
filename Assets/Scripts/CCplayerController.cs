using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCplayerController : MonoBehaviour
{
    private CharacterController controller;
    
    public float moveSpeed = 8f;
    public float dashPower = 2f;
    public float dashStorage = 100f;
    public float dashRegeneration = 2f;
    public float jumpHeight = 4f;
    public string state = "normal";
    public float characterHeight = 2f;
    public AudioClip[] walk;
    public AudioSource audioSource;
    private float gravity = -9.81f; 
    private Vector3 velocity;
    private bool dashInput = false;
    private float counter;
    void Start(){
        controller = GetComponent<CharacterController>();
        state = "inactive";
    }

    void Update(){
        switch (state){
            case "normal":
                get_input();
                move();
                
                bool onGround = checkHeight();
                if (onGround){
                    velocity.y -= 0.1f;
                }else{
                    velocity.y += gravity * 2 * Time.deltaTime;
                }
                
                if (Input.GetKeyDown(KeyCode.Space) && onGround){
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); 
                }
                controller.Move(velocity * Time.deltaTime);
                break;
            case "move to normal":
                counter += Time.deltaTime;
                if(counter >= 0.2){
                    counter = 0;
                    state = "normal";
                }
                break;
        }


    }   

    private void get_input(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            dashInput = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            dashInput = false;
        }
    }
    private void move(){
        float xDir = Input.GetAxis("Horizontal");
        float yDir = Input.GetAxis("Vertical");
        
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
        }
    }

    private bool checkHeight(){
        Vector3 hoverSensor = transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit)){
            if (hit.distance <= characterHeight){
                return true;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }
}
