using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public static Timer timer;


    public float timeRemaining = 10;
    public bool timerIsRunning = false;

    private void Awake()
    {
        timer = this;
    }

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = false;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                Debug.Log(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
