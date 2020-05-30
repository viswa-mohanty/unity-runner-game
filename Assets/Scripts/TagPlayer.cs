using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagPlayer : MonoBehaviour
{

    public Transform target;
    public float tagForwardSpeed;
    //public Transform myTransform;

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        transform.LookAt(target);
        transform.Translate(Vector3.forward * tagForwardSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerManager.tagged = true;
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }

}
