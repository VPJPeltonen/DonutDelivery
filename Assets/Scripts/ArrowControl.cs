using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowControl : MonoBehaviour
{
    public Transform MagneticNorth;
    private bool active = true;
    /*
    private bool active = false;
    private GameControl gm;
    public bool Active { get => active; set => active = value; }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindWithTag("GameController").GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!active){return;}
        transform.LookAt(gm.GetNextGate().transform);
    }*/
    void Update()
    {
        if(!active){return;}
        Vector3 MagneticNorthDir = new Vector3(transform.position.x,MagneticNorth.position.y,MagneticNorth.position.z);
        transform.LookAt(MagneticNorthDir);
    }
}
