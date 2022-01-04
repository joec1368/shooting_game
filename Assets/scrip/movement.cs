using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Vector3 MovingDirection;
    [SerializeField] float movingSpeed = 10f;


    // MeshRenderer mr;
    Rigidbody rb;
    int judge = 0;
    bool run;

    [SerializeField] float JumpingForce = 10f;




    void Awake()
    {
        Debug.Log("awake");
    }
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Start");

        Transform tm = GetComponent<Transform>();



        // mr = GetComponent<MeshRenderer>();

        //tm.position = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        //mr.material.color = new Color((int)Time.time % 2 * 255f, 255f, 255f);
        run = false;

        if (Input.GetKey(KeyCode.W))
        {
            run = true;
            float x = transform.rotation.x;
            float y = transform.rotation.y;
            float z = transform.rotation.z;
            Vector3 myVector = new Vector3(x, 0, z);
            transform.localPosition += movingSpeed * Time.deltaTime * myVector;

        }
        if (Input.GetKey(KeyCode.A))
        {
            run = true;
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            run = true;
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            run = true;
            transform.localPosition += movingSpeed * Time.deltaTime * Vector3.right;
        }
    }


}
