using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeropen : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.active == false)
        {
            player.SetActive(true);
        }
    }
}
