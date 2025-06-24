using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Obstacels : MonoBehaviour
{
   

    public bool isBug, isWall, isFragment, isSpike;
    public PlayerMovement playerMovement;

    public static bool paused;

    public float FragmentSpeed = 5;

    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    private Vector3 startPosition;

    [Tooltip("How long to wait before restarting the game")]
    public float waitTime = 3.0f;

    public Animator animator;

    public GameObject Player;


    


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isFragment)
        {
            float movement = Mathf.PingPong(Time.time * FragmentSpeed, rightLimit - leftLimit) + leftLimit;
            transform.position = new Vector3(movement, startPosition.y, startPosition.z);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (isBug)
            {
                playerMovement.SlowDown();
                print("slow");
                this.gameObject.SetActive(false);
            }
            if (isWall)
            {
                death();
            }
            if (isFragment || isSpike)
            {
                death();

            }
        }
    }
    public void death()
    {

        playerMovement.isDead = true;

        animator.SetTrigger("DeathAnim");
       // Time.timeScale = (paused) ? 0 : 1;
        // Destroy the player
        // Call the function ResetGame after waitTime has passed
       
        //or restart panel
        Invoke("ResetGame", waitTime);
    }

    /// <summary>
    /// restart level
    /// </summary>
    private void ResetGame()
    {
        // Get the current level's name
        string sceneName = SceneManager.GetActiveScene().name;
        // Restarts the current level
        SceneManager.LoadScene(sceneName);
    }
}
