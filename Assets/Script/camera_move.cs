using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0.3f, 0f, 0f);
        if (transform.position.x <= 300)
        {
            transform.position = new Vector3(1145.347f, 199.5274f, 272.9381f);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }
}
