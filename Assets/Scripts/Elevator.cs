using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public static Elevator elevator;
    public float speed;
    public bool canMoveToTop;

    // Start is called before the first frame update

    private void Awake()
    {
        elevator = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canMoveToTop)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            transform.position = temp;

         
        }

     
    }
}
