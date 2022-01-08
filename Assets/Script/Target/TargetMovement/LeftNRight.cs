using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftNRight : MonoBehaviour
{
    //[SerializeField] GameObject target ;
    private float target2Speed = 5f ;
    //public Transform MovePosition ;

    private Vector3 StartPosition ;

    private Vector3 EndPosition ;
    private bool OnTheMove ;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = this.transform.position ;        
        //EndPosition = MovePosition.position ;
        EndPosition = StartPosition ;
        EndPosition.x += 10 ;
    }

    // Update is called once per frame
    void Update()
    {
        float step = target2Speed * Time.deltaTime ;

        if(OnTheMove == false){
            this.transform.position = Vector3.MoveTowards (this.transform.position, EndPosition, step) ;
        }else{
            this.transform.position = Vector3.MoveTowards (this.transform.position, StartPosition, step) ;
        }

        if(this.transform.position.x == EndPosition.x && this.transform.position.y == EndPosition.y && OnTheMove == false){
            OnTheMove = true ;
        }else if(this.transform.position.x == StartPosition.x && this.transform.position.y == StartPosition.y && OnTheMove == true){
            OnTheMove = false ;
        }
    }
}
