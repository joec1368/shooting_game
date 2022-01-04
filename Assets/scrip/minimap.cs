using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponentInParent<Transform>();
        
        Transform position = gameObject.GetComponent<Transform>();
        position = player;
        Camera camera = gameObject.GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        player = gameObject.GetComponentInParent<Transform>();

        Transform position = gameObject.GetComponent<Transform>();
        position = player;
        


    }
}
