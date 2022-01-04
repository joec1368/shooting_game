using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Character_Controller : MonoBehaviour
{
    [SerializeField] float MoveSpeed = 0.5f;
    bool isrun, isjump, reload, fire,slide;
    public AudioClip firing;
    public AudioSource audiosource;
    Animator animator;
    Rigidbody rb;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        isrun = false;isjump = false;reload = false;fire = false;slide = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audiosource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        isrun = false;fire = false;
        ///Move
        if (Input.GetKey(KeyCode.W)&&!reload&&!fire)
        {
            transform.position += MoveSpeed * Time.deltaTime * transform.forward;
            isrun = true;
            reload = false; fire = false;
        }
        if (Input.GetKeyDown(KeyCode.A)) transform.Rotate(new Vector3(0f, -90f, 0f));
        if (Input.GetKeyDown(KeyCode.S)) transform.Rotate(new Vector3(0f, 180f, 0f));
        if (Input.GetKeyDown(KeyCode.D)) transform.Rotate(new Vector3(0f, 90f, 0f));
        if(Input.GetKeyDown(KeyCode.Space)&&isjump == false)
        {
            isjump = true;
            rb.velocity =  new Vector3(0, 7, 0);
            Debug.Log(rb.velocity);
        }
        if (Input.GetKeyDown(KeyCode.R) && !reload)
        {
            reload = true;
            t = Time.time;
        }
        if (isrun && Input.GetKey(KeyCode.LeftControl)) slide = true;
        if (Input.GetKeyUp(KeyCode.LeftControl)) slide = false;
        if (Time.time - t >= 2.3f&&2.4f>=Time.time - t) reload = false;
        if (Input.GetMouseButton(0) && !isrun && !isjump && !reload) fire = true;
        if(Input.GetMouseButton(0)&&!isrun&&!isjump&&!reload&&!audiosource.isPlaying) audiosource.PlayOneShot(firing);
        ////animator setting
        if (isjump) isrun = false;
        animator.SetBool("isrun", isrun);
        animator.SetBool("isjump", isjump);
        animator.SetBool("reload", reload);
        animator.SetBool("fire", fire);
        animator.SetBool("slide", slide);
        ////audio
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.transform.name == "ground") isjump = false;
    }
}



