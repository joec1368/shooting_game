using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class position : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Transform>();

        Transform position = gameObject.GetComponent<Transform>();
        position = player;

    }

    // Update is called once per frame
    void Update()
    {
        //player = gameObject.GetComponent<Transform>();
        camera.position = player.position;



    }
}
