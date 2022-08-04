using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{

   

    public float thrust; //jump force
    [HideInInspector]
    public Rigidbody rb;
    public static PlayerManager playerManager;

    public bool isGrounded = true;
    //public float gravityScale = 5;

    public float buttonTime = 0.0f;
    //    float jumpTime;
    //    bool jumping;

   

    private void Awake()
    {
        playerManager = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       // GameObject.FindWithTag("BackgroundAmbianceSound").GetComponent<AudioSource>().Play();

    }

    void Update()
    {
        Jump();
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
           // Debug.Log("isGrounded");
        }

    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
           // Debug.Log("isGrounded");
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
           // Debug.Log(" ! isGrounded"); 
        }

    }

    private void Jump()
    {
       // Vector3 tilt = new Vector3(Input.acceleration.x, 0, -Input.acceleration.z);

        int fingerCount = 0;
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled && isGrounded)
                fingerCount++;

        }

        if (fingerCount == 1)
        {
           // jumping = true;
           // jumpTime = 0;

            rb.AddForce((Vector3.up) * thrust, ForceMode.Impulse);    //or any force mode you prefer
                                                                      // isGrounded = false;
            GameObject.FindWithTag("PlayerJumpSound").GetComponent<AudioSource>().Play();
          
        }
        else if (fingerCount == 2)
        {
            // do another thing if 2 fingers
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce((Vector3.up) * thrust, ForceMode.Impulse);      //or any force mode you prefer
            isGrounded = false;                                                      // isGrounded = false;
        

        }



        //if (jumping)
        //{
        //    jumpTime += Time.deltaTime;
        //}

        //if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        //{
        //    jumping = false;
        //}

    }





}
