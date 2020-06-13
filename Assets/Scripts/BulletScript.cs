using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject Explosion;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            other.GetComponent<ShipController>().Damage(1);
            var explosion = Instantiate(Explosion, transform.position, transform.rotation, other.transform);
            Destroy(gameObject);
            
        }
    }
}
