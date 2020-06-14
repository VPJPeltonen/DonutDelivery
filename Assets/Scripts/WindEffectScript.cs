using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffectScript : MonoBehaviour
{
    private float counter;

    void Update(){
        counter += Time.deltaTime;
        if(counter >= 5f){
            Destroy(gameObject);
        }
    }
}
