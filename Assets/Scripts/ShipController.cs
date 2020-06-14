using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float speed;
    public GameObject Donuts;
    public AudioClip explosion;
    public GameControllerScript GM;
    public mouseLook mouse;
    public bool hasDonuts;
    private float zRotation;
    private float stabilisingSpeed = 0.01f;
    private Rigidbody body;
    private UIScript UI;
    private CameraShake shake;
    private int health = 6;
    private AudioSource ASource;
    private string state;
    void Start()
    {
        zRotation =  0f;
        body = gameObject.GetComponent<Rigidbody>();
        ASource = gameObject.GetComponent<AudioSource>();
        UI = GameObject.FindWithTag("UI").GetComponent<UIScript>();
        shake = GameObject.FindWithTag("Shaker").GetComponent<CameraShake>();
    }

    void FixedUpdate()
    {
        switch(state){
            case "normal":
                move();
                break;
        }
    }

    public void StartGame(){
        state = "normal";
    }

    public void Damage(int damage){
        shake.StartShake(0.1f);
        health -= damage;
        UI.UpdateHealth(health);
        ASource.PlayOneShot(explosion, 0.7f);
        if(health <= 0){
            GM.GameOver();
            state = "dead";
            mouse.GameOver();
        }
    }

    public void TargetTriggered(bool isSource){
        Donuts.SetActive(isSource);
        hasDonuts = isSource;
        GM.IndicatorActivated(isSource,transform.position);
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
