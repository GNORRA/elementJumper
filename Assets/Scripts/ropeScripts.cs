using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeScripts : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
      //  GetComponent<CharacterJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
       
      
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Bing" && !PlayerManager.playerManager.isGrounded)
        {
           // Debug.Log("Bing");
            ScoreManager.scoreManager.score++;
            PowerProgress.powerProgress.CurrentValue +=0.025f;

        }

        if (other.gameObject.tag == "Player" && PlayerManager.playerManager.isGrounded)
        {
           // Debug.Log("Player touched");
            ScoreManager.scoreManager.health--;
            CameraRotator.cameraRotator.CheckAnimCameraFaile();
            GameObject.FindWithTag("RopeHitSound").GetComponent<AudioSource>().Play();

        }



    }

    

  


}
