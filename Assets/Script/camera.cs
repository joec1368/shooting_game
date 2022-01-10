using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speedH = 2f, speedV = 2f;
    public float pitch = 0f, yaw = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//cursor
    }

    // Update is called once per frame
    void Update()
    {
        yaw -= speedH * Input.GetAxis("Mouse Y");
        pitch += speedV * Input.GetAxis("Mouse X");
        if (yaw > 22) yaw = 22;
        else if (yaw < -30) yaw = -30;
        transform.eulerAngles = new Vector3(yaw, pitch, 0f);
    }
}
