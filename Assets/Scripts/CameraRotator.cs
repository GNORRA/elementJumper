using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{

    public float speed;
    public Transform cameraRotate;
    public bool state;
    public bool animRotateCamera = false;

    public Animator anim;
   

    public static CameraRotator cameraRotator;

    private void Awake()
    {
        cameraRotator = this;
    }

    
   
    // Update is called once per frame
    void Update()
    {
        if (animRotateCamera)
        {
            StartCoroutine(CameraAnimRotator());
        }
    }

    IEnumerator CameraAnimRotator()
    {
       
            yield return new WaitForSeconds(.5f);
           
            transform.Rotate(0, speed * Time.deltaTime, 0);

            if (cameraRotate.eulerAngles.y >= 70)
            {
                speed = 0f;
                yield return new WaitForSeconds(5f);
                speed = -8f;
                yield return new WaitForSeconds(5f);
                speed = 0f;
                animRotateCamera = false;
               
        }

    }

   public void CheckAnimCameraFaile()
    {
        anim.SetTrigger("CheckCamFaile");
    }
}
