﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUpFries");
            PlayerManager.numberOfFries += 1;
            Destroy(gameObject);
        }
    }
}
