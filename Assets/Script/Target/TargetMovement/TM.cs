using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TM : MonoBehaviour
{   
    private float target2Speed = 5f ;
    private Vector3 StartPosition ;
    private Vector3 EndPosition ;
    private bool OnTheMove ;
    public float cur_time;
    public bool t = true;//control move left or right

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = this.transform.position;
        //EndPosition = MovePosition.position ;
        EndPosition = StartPosition;
        EndPosition.x += 10;
        cur_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float step = target2Speed * Time.deltaTime;
        if(Time.time - cur_time > 1f) {
            cur_time = Time.time;
            t = !t;
        }
        if (t)
        {
            transform.Translate(target2Speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.Translate(-target2Speed * Time.deltaTime, 0f, 0f);
        }

        if (this.transform.position.x == EndPosition.x && this.transform.position.y == EndPosition.y && OnTheMove == false)
        {
            OnTheMove = true;
        }
        else if (this.transform.position.x == StartPosition.x && this.transform.position.y == StartPosition.y && OnTheMove == true)
        {
            OnTheMove = false;
        }
    }
}
