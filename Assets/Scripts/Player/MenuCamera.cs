using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    public Transform target;
    private int count;

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.left * 1.5f * Time.deltaTime);


    }
        
    
}
