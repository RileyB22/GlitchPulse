using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProUGUI

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
    public bool isDead = false;

    public Animator animator;

    [Header("Object References")]
    public TextMeshProUGUI scoreText;

    public float score = 0;
    public float Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;

            /* Check if scoreText has been assigned */
            if (scoreText == null)
            {

                Debug.LogError("Score Text is not set. " +
                "Please go to the Inspector and assign it");
                /* If not assigned, don't try to update it. */
                return;
            }

            /* Update the text to display the whole number portion
            /*  of the score */
            scoreText.text = string.Format("{0:0}", score);

            //High score stuff
            int highScore = (int)score;
            scoreText.text = highScore.ToString();

            /*if(PlayerPrefs.GetInt("score")<=highScore)
            {
                PlayerPrefs.SetInt("score", highScore);
            }*/
            // same ig 

            if (highScore > PlayerPrefs.GetInt("score"))
            {
                PlayerPrefs.SetInt("score", highScore);
            }

        }
    }


    void Start()
    {
       // animator = GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
        currentSpeed = playerSpeed;

        Score = 0;
    }
    void FixedUpdate()
    {
        /* If the game is paused, don't do anything */
        if (PauseScreen.paused)
        {
            return;
        }
    }


    void Update()
    {

        /* Using Keyboard/Controller to toggle pause menu */
        if (Input.GetButtonDown("Cancel"))
        {
            // Get the pause menu
            var pauseBehaviour = GameObject.FindObjectOfType<PauseScreen>();

            // Toggle the value
            pauseBehaviour.SetPauseMenu(!PauseScreen.paused);
        }

        /* If the game is paused, don't do anything */
        if (PauseScreen.paused)
        {
            return;
        }
        Score += Time.deltaTime;


        //move forward
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed, Space.World);

        // SWIPE UP
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("JumpAnim");
            GetComponent<Animator>().SetTrigger("Open");

            //tell it to stop moving
            if (isDead == true)
            {
                currentSpeed = 0;
            }
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
        animator.SetTrigger("StumbleAnim");
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
