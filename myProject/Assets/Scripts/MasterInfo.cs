using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MasterInfo : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private float Scores = 1000;

    public GameObject creditScreen;
   // public Animator animator;
    

    //when to spawn others

    // GetComponent<ObstacleSpawner>().SpawnObstacles();

    // static means other stuffs can interact w/ it
    // public static int coinCount = 0;
    //  [SerializeField] GameObject coinDisplay;



    // Start is called before the first frame update
    void Start()
    {
        // SpawnObstacles();
        creditScreen.SetActive(false);
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
   private void Update()
    {
        float getScore = playerMovement.score;

        if (getScore > Scores)
        {
            creditScreen.SetActive(true);
           // animator.SetTrigger("CreditAnim");
        }


        //coinDisplay.GetComponent <TMPro.TMP_Text>().text = "COINS: " + coinCount;
    }


   
        /*public void SpawnObstacles()
        {
            foreach (Transform point in spawnPoints)
            {
                if (Random.value > 0.5f) // 50% chance to spawn
                {
                    int index = Random.Range(0, obstaclePrefabs.Length);
                    Instantiate(obstaclePrefabs[index], point.position, point.rotation);
                }
            }
        }*/
}
