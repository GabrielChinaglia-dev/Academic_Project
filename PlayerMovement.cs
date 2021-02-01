using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float spd = 0f;
    public bool canJump = false;
    public bool jumping = false;

    public GameObject curWeapon;

    public Animator anim;

    //private float speedH = 2.0f;
    //private float speedV = 2.0f;
    //private float yaw = 0.0f;
    //private float pitch = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.Find("SCR-L").gameObject.active = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * 3f);
        if(Input.GetKey("w") && !Input.GetKey("r"))// O "!" antes do Input significa "Nao".
        {
            transform.position += transform.forward * spd;
            if (!jumping) anim.Play("Running");
            transform.Find("SCR-L").gameObject.active = false;
            transform.Find("Italian machine guns").gameObject.active = false;
        }
        if(Input.GetKeyUp("w"))
        {
            anim.Play("Idle");
        }
        if(Input.GetKey("s"))
        {
            transform.position += transform.forward * -spd;
            if(!jumping) anim.Play("Running_Backward");
            transform.Find("SCR-L").gameObject.active = false;
            transform.Find("Italian machine guns").gameObject.active = false;
        }
        if(Input.GetKeyUp("s"))
        {
            anim.Play("Idle");
        }
        if(Input.GetKey("a"))
        {
            float dir = transform.eulerAngles.y +90.0f;
            Vector3 spdTemp = new Vector3(Mathf.Sin(dir * Mathf.Deg2Rad),0,Mathf.Cos(dir * Mathf.Deg2Rad));
            transform.position = transform.position + (spdTemp * -spd);
        }
        if(Input.GetKey("d"))
        {
            float dir = transform.eulerAngles.y -90.0f;
            Vector3 spdTemp = new Vector3(Mathf.Sin(dir * Mathf.Deg2Rad),0,Mathf.Cos(dir * Mathf.Deg2Rad));
            transform.position = transform.position + (spdTemp * -spd);
        }

        

        //Mirando

        if(Input.GetMouseButtonDown(1))
        {
            anim.Play("Aiming_Idle");
            transform.Find("SCR-L").gameObject.active = true; 
        }

        
        //Pulo do Player
        if(Input.GetKey("space"))
        {
            if(canJump)
            {
                jumping = true;
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(0,4f,0), ForceMode.Impulse);
                anim.Play("Jump");
                canJump = false;
            }
        }
        
        //Movimento da camera com o teclado
        /*
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0,-2f,0);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0,2f,0);
        }
        */

        //Movimento da camera com o mouse
        /*
        pitch -= speedV * Input.GetAxis("Mouse Y");
        yaw += speedH * Input.GetAxis("Mouse X");
        transform.eulerAngles = new Vector3(pitch, yaw, 0);
        */
    }
     void OnCollisionEnter(Collision obj)
    {
        if(obj.gameObject.tag == ("Floor"))
        {
            canJump = true;
            jumping = false;
            //Debug.Log("pode pular!");
        }
    }
}