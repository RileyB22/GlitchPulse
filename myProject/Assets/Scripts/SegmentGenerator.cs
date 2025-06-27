using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    //public GameObject[] segment;
    public GameObject segment;

    [SerializeField] int zPos = 50;
    [SerializeField] bool creatingSegment = false;
   // [SerializeField] int segmentNum;
    [Tooltip("How much time to wait before destroying" + "the tile after reaching the end")]
    public float destroyTime = 1.5f;

    //obstacles
    public GameObject[] obstaclePrefabs;
    public Transform[] spawnPoints;
    private List<GameObject> activeObstacles = new List<GameObject>();
    //public int requiredCheckpointID;
   // private bool hasSpawned = false;

    private PlayerMovement playerMovement;
    private float Scores;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
      //  Destroy(gameObject, 15f);

    }

    // Update is called once per frame
    void Update()
    {
        if (!creatingSegment)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }

        
    }

    IEnumerator SegmentGen()
    {
        //segmentNum = Random.Range(0, 3);
        // Instantiate(segment/*[segmentNum]*/, new Vector3(0, 0, zPos), Quaternion.identity);
        //int segmentNum = Random.Range(0, segment.Length);
        GameObject newSegment = Instantiate(segment, new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        // Try to spawn obstacles based on score
       // float getScore = playerMovement.score;
        UpdateObstaclePool(playerMovement.score);
        SpawnObstacles(newSegment.transform);

        yield return new WaitForSeconds(3);
        creatingSegment = false;

       /* ObstacleSpawner spawner = newSegment.GetComponent<ObstacleSpawner>();
        if (spawner != null)
        {
            int currentScore = FindObjectOfType<MasterInfo>().score;
            spawner.TrySpawn(currentScore);
        }*/
       
  
        //destroy if not already
        //Destroy(transform.parent.gameObject, destroyTime);
      
    }
    void UpdateObstaclePool( float getScore)
    {
        getScore = playerMovement.score;
        activeObstacles.Clear();
        if (getScore >= 0) activeObstacles.Add(obstaclePrefabs[0]);
        if (getScore >= 15 && obstaclePrefabs.Length > 1) activeObstacles.Add(obstaclePrefabs[1]);
        if (getScore >= 40 && obstaclePrefabs.Length > 2) activeObstacles.Add(obstaclePrefabs[2]);
        if (getScore >= 50 && obstaclePrefabs.Length > 3) activeObstacles.Add(obstaclePrefabs[3]);
        if (getScore >= 70 && obstaclePrefabs.Length > 4) activeObstacles.Add(obstaclePrefabs[4]);

    }

    void SpawnObstacles(Transform parent)
    {
        Transform[] localSpawnPoints = parent.GetComponentsInChildren<Transform>();
        foreach (Transform point in localSpawnPoints)
        {
            if (point.CompareTag("SpawnPoint") && activeObstacles.Count > 0)
            {
                // 50% spawn chance
                if (Random.value > 0.5f)
                {
                    int index = Random.Range(0, activeObstacles.Count);
                    Instantiate(activeObstacles[index], point.position, point.rotation, parent);
                }
               
            }
        }
    }


   /* public void TrySpawn(int checkpointID, int score)
    {
        int currentScore = FindObjectOfType<MasterInfo>().score;
        spawner.TrySpawn(currentScore);

        if (!hasSpawned && checkpointID == requiredCheckpointID)
        {
            UpdateObstaclePool(score);
            SpawnObstacles();
            hasSpawned = true;
        }
    }*/


}
