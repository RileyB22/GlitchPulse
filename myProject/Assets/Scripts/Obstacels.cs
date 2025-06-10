using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacels : MonoBehaviour
{

    public bool isBug, isWall, isFragment, isSpike;
    public PlayerMovement playerMovement;

    public static bool paused;

    public float FragmentSpeed = 5;

    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;

    private Vector3 startPosition;

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
    public void death()
    {
        // stop movement   HOW DO I GET HS FROM THIS?
      paused = true;
      Time.timeScale = (paused) ? 0 : 1;
    }
}
