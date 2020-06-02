using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;
    public float laneDistance = 4;
    //public bool isGrounded;

    public float jumpForce;
    public float jumpDistance;
    public float Gravity = -20;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
            return;

        if (forwardSpeed < maxSpeed)
            forwardSpeed += 0.05f * Time.deltaTime;

        direction.z = forwardSpeed;
        animator.SetFloat("Speed", forwardSpeed);
        animator.SetBool("isGrounded", controller.isGrounded);


        //direction.y += Gravity * Time.deltaTime;

        /* if (controller.isGrounded)
         {
             if (Input.GetKeyDown(KeyCode.UpArrow))
             {
                 Jump();
             }
         }*/

        //direction.y = -1;
        if (SwipeManager.swipeUp)
        {
            Jump();
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;

        }

        if (SwipeManager.swipeDown)
        {
            StartCoroutine(Slide());
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
            
        }



        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;

        }

       
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        //transform.position = targetPosition;
        transform.position = Vector3.Lerp(transform.position, targetPosition, 40 * Time.deltaTime);
        controller.center = controller.center;

    }

    private void FixedUpdate()
    {
        if (!PlayerManager.isGameStarted)
            return;

        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
        direction.z = jumpDistance;

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacles")
        {
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            StartCoroutine(Fall());
            //PlayerManager.gameOver = true;
            
        }
    }

    private IEnumerator Slide()
    {
        animator.SetBool("IsSliding", true);

        yield return new WaitForSeconds(0.8f);

        animator.SetBool("IsSliding", false);


    }

    private IEnumerator Fall()
    {
        animator.SetBool("IsFall", true);
        yield return new WaitForSeconds(0.2f);
        PlayerManager.gameOver = true;


    }

}
