using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Character_Controller : MonoBehaviour
{
    //shoot
    public Camera cam;
    public GameObject impact;
    public ParticleSystem muzzle;

    public float damage = 10f;
    public float firerate = 15f;
    public float range = 100f;
    /// 
    [SerializeField] float MoveSpeed = 0.5f;
    bool isrun, isjump, reload, fire, slide, r_s, r_r;
    public AudioClip firing;
    public AudioClip reLoad;
    public AudioSource audiosource;
    public float speedH = 2f, speedV = 2f;
    public float pitch = 0f, yaw = 0f;
    Animator animator;
    public Animation amin;//use to shoot and run
    Rigidbody rb;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//cursor
        isrun = false; isjump = false; reload = false; fire = false; slide = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audiosource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        isrun = false; fire = false; r_s = false; r_r = false;
        ///Move
        if (Input.GetKey(KeyCode.W)) transform.position += MoveSpeed * Time.deltaTime * transform.forward;
        if (Input.GetKey(KeyCode.A)) transform.Translate(-MoveSpeed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.S)) transform.position -= MoveSpeed * Time.deltaTime * transform.forward;
        if (Input.GetKey(KeyCode.D)) transform.Translate(MoveSpeed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            isrun = true;
            //audiosource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isjump == false && slide == false)
        {
            isjump = true;
            rb.velocity = new Vector3(0, 7, 0);
            Debug.Log(rb.velocity);
        }
        if (isrun && Input.GetKey(KeyCode.LeftControl)) slide = true;
        if (Input.GetKeyDown(KeyCode.R) && !reload && !slide)
        {
            audiosource.PlayOneShot(reLoad);
            reload = true;
            t = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.LeftControl)) slide = false;
        if (Time.time - t >= 2.3f && 2.4f >= Time.time - t) reload = false;
        if (Input.GetMouseButton(0) && !isjump && !reload) fire = true;
        if (Input.GetMouseButton(0) && !isjump && !slide && !reload && !audiosource.isPlaying)
        {
            audiosource.PlayOneShot(firing);
            ShootLinear();
        }
        if (fire && isrun) r_s = true;
        if (reload && isrun) r_r = true;
        ////animator setting
        if (isjump) isrun = false;
        if (r_s) fire = false;
        if (isjump || slide)
        {
            audiosource.Stop();
            reload = false;
            r_s = false;
            fire = false;
        }
        animator.SetBool("isrun", isrun);
        animator.SetBool("isjump", isjump);
        animator.SetBool("reload", reload);
        animator.SetBool("fire", fire);
        animator.SetBool("slide", slide);
        animator.SetBool("r_s", r_s);
        animator.SetBool("r_r", r_r);
        ///audio
        ///cursor
        yaw -= speedH * Input.GetAxis("Mouse Y");
        pitch += speedV * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(yaw, pitch, 0f);
        ///shoot

    }
    void ShootLinear()
    {
        muzzle.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log("Hit " + hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            target.Hit();

            GameObject impactGO = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        isjump = false;
    }
}



