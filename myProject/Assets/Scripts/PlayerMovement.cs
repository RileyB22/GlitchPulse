using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float playerSpeed = 2;
    public float slowSpeed = 1;
    public float slowTime = 2;
    public float horizontalSpeed = 3;

    public float jumpForce = 5;
    private bool isGrounded;

    private float currentSpeed;

    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = playerSpeed;
    }

   
    void Update()
    {
        //move forward
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.World);

        // SWIPE UP
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        //are we moving? WILL NEED TOUCH INPUT!!!!
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))  // left swipe 
        {
            if (this.gameObject.transform.position.x > leftLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // right swipe
        {
            if (this.gameObject.transform.position.x < rightLimit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true; // on ground
    }


    public void SlowDown()
    {
        StartCoroutine(SlowDownCoroutine());
    }

    private IEnumerator SlowDownCoroutine()
    {
        currentSpeed = slowSpeed;
        yield return new WaitForSeconds(slowTime);
        currentSpeed = playerSpeed;
        print("did it");
    }

    public float GetCurrentSpeed()
    {
        return currentSpeed;
    }

}
