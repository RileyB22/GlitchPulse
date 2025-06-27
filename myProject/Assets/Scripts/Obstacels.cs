using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.Universal;


public class Obstacels : MonoBehaviour
{
   

    public bool isBug, isWall, isFragment, isSpike, isGlitch;
    public PlayerMovement playerMovement;

    public static bool paused;

    public float FragmentSpeed = 5;

    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

   // private float glitchDelay = 3f;
    private Vector3 startPosition;

    [Tooltip("How long to wait before restarting the game")]
    public float waitTime = 3.0f;

    public AudioSource audioSource;
    public AudioClip bugSound;
    public AudioClip errorSound;
    public AudioClip wallSound;

    // public bool isInvon = false;
    //public GameObject glitchVolume;
   // public Volume postProcessingVolume;


    public Animator animator;

    public GameObject Player;






    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        startPosition = transform.position;
        GetComponent<Renderer>().enabled = true;



        /*if (postProcessingVolume.profile.TryGet(out vignette))
        {
            vignette.active = true;
        }*/
        //Rigidbody rb = other.GetComponent<Rigidbody>();
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
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null && !player.isInvincible)
            {
                if (isBug)
                {
                    playerMovement.SlowDown();
                    print("slow");
                    audioSource.PlayOneShot(bugSound);
                    this.gameObject.SetActive(false);
                }
                if (isWall)
                {
                    audioSource.PlayOneShot(wallSound);
                    death();
                }
                if (isFragment || isSpike)
                {
                    audioSource.PlayOneShot(errorSound);
                    death();

                }
                if (isGlitch)
                {
                    if (other.CompareTag("Player"))
                    {
                        // Collider playerCol = other.GetComponent<Collider>();

                       // isInvon = true;
                        // playerCol.enabled = false;
                        player.isInvincible = true;
                        //glitchVolume.enabled = true;
                       // vignetteVolume.weight = Mathf.Lerp(0f, 1f, t);

                        StartCoroutine(EndInvincibility(player, 5f));

                        //audioSource.PlayOneShot(wallSound);
                        print("glitch");
                        //this.gameObject.SetActive(false);
                       // this.enabled == true
                        GetComponent<Renderer>().enabled = false;
                    }
           
                }

            }
        }
    }
    IEnumerator EndInvincibility(PlayerMovement player, float delay)
    {
        
        yield return new WaitForSeconds(delay);
       // glitchVolume.enabled = false;

        //col.enabled = true;
        player.isInvincible = false;
        print("Invinc end");
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
