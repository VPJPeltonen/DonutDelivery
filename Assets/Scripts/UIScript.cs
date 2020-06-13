using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public GameObject[] HealthHearts;
    private int healthAmount;
    // Start is called before the first frame update
    void Start()
    {
        healthAmount = HealthHearts.Length;
    }

    public void UpdateHealth(int health){
        HealthHearts[health].SetActive(false);
    }
}
