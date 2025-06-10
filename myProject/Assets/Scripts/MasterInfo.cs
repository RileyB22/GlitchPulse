using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterInfo : MonoBehaviour
{
    // static means other stuffs can interact w/ it
    public static int coinCount = 0;
    [SerializeField] GameObject coinDisplay;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent <TMPro.TMP_Text>().text = "COINS: " + coinCount;
    }
}
