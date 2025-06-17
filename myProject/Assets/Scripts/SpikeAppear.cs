using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAppear : MonoBehaviour
{

    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spike.transform.position += new Vector3(0, 1.5f, 0);

            Debug.Log("trigger");
            
        }
    }

}
