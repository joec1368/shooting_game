using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        //player = gameObject.GetComponentInParent<Transform>();
        
        //Transform position = gameObject.GetComponent<Transform>();
        //position = player;
        //Camera camera = gameObject.GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // player = gameObject.GetComp<Transform>();

        // Transform position = gameObject.GetComponent<Transform>();
        float x = player.position.x;
        float z = player.position.z;
        float y = gameObject.transform.position.y;

      
        gameObject.transform.position = new Vector3(x, y, z);
        gameObject.transform.eulerAngles = new Vector3(90f, player.eulerAngles.y, 0f);


    }
}
