﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public enum State
{
    emptyFreezy,
    emptyLucky,
    emptyClassic,
    reload,
    classic,
    freezy,
    luky
}


public class SphereRotation : MonoBehaviour
{


    public State currentState;

    public static SphereRotation sphereRotation;
   
    public GameObject target;
    int times = 0;
    [SerializeField]
    float chrono;
    int chronoValue1;
    int chronoValue2;
    int chronoIntValue;

    [Header("The axis by which it will rotate around")]
    public Vector3 axis;

    [Header("Speed of rotation")]
    public float angle; //or the speed of rotation.

    bool Completed = false;
    int robeTimerValue;
    float robeTimer;
    int intRobeTimer;
    public GameObject robeObject;

    [Header("SpeedPeriod")]
    float speedPeriod = 3f;

    [Header("Speed VariationCounter")]
    float speedVariationCounter = 0.1f;



    public Text timerText;
    public float time = 0.0f;
    public float chronoToStart = 5f;
    public GameObject TimerToStart;


    public int[] LevelStepsNum;


    public int canNextStep = 0;

    public int nbreTime;

    private void Awake()
    {
        sphereRotation = this;
    }

    void Start()
    {

        LevelStepsNum = new int[3];

        for (int i = 0; i < LevelStepsNum.Length; i++)
        {
            LevelStepsNum[i] = Random.Range(10, 100);


            Debug.Log(LevelStepsNum[i]);

        }

        currentState = State.classic;

        TimerToStart.SetActive(true);

        ////For level Easy////
           

        ////For level Medium////

        robeTimerValue = Random.Range(10, 20);

        ////For level Hard////

        chronoValue1 = Random.Range(10, 20);
       // Debug.Log("ChronoValue 1 : " + chronoValue1);

        chronoValue2 = Random.Range(10, 20);
        //  Debug.Log("ChronoValue 2 : " + chronoValue2);


      //  Debug.Log("Angle/Speed " + angle);



    }

    // Update is called once per frame
    void Update()
    {


       
        // string isClassic = PlayerPrefs.GetString("classic");
        chronoToStart -= 1f * Time.deltaTime;
        timerText.text = chronoToStart.ToString("0");

        if (chronoToStart <= 1f)
        {

            Timer.timer.timerIsRunning = true;

            TimerToStart.SetActive(false);
            
            if (currentState == State.classic )
            {
                Classic();

              if(Timer.timer.timeRemaining == 0)
                {
                    currentState = State.emptyClassic;

                    if (ScoreManager.scoreManager.health > 0)
                    {
                       
                        GameMenuManager.gameMenuManager.DisplaySpecialRating();
                        

                    }
                  

                  
                }
               


            }
            
        }
        if (canNextStep == 1 && currentState == State.emptyClassic)
        {
            canNextStep = 0;
            currentState = State.freezy;
            Timer.timer.RealoadTimer();
        }


        if (currentState == State.freezy)
        {
            Freezy();

            if (Timer.timer.timeRemaining == 0)
            {
                currentState = State.emptyFreezy;

                if(ScoreManager.scoreManager.health > 0)
                {
                    GameMenuManager.gameMenuManager.DisplaySpecialRating();
                }
                
            }
        }
        if (canNextStep == 1 && currentState == State.emptyFreezy)
        {
            canNextStep = 0;
            currentState = State.luky;
            Timer.timer.RealoadTimer();
        }

        if(currentState == State.luky)
        {
            Lucky();
            if(Timer.timer.timeRemaining == 0)
            {
                currentState = State.emptyLucky;

                if(ScoreManager.scoreManager.health > 0)
                {
                    GameMenuManager.gameMenuManager.DisplaySpecialRating();
                }
               
            }
        }
        if (canNextStep == 1 && currentState == State.emptyLucky)
        {
            canNextStep = 0;
            currentState = State.classic;
            Timer.timer.RealoadTimer();
        }


        //if(currentState == State.classic)
        //{
        //    Classic();
        //    if(Timer.timer.timeRemaining == 0)
        //    {
        //        currentState = State.emptyClassic;
        //        if(ScoreManager.scoreManager.health > 0)
        //        {
        //            GameMenuManager.gameMenuManager.DisplaySpecialRating();
        //        }
        //    }
        //}



    }























    /// <summary>
    /// METHODE
    /// </summary>

   public void Classic()
        {
      
            Debug.Log("RUN CLASSIC");


            speedVariationCounter += Time.deltaTime;
            // Debug.Log("SVCounter " + speedVariationCounter);

            if (speedVariationCounter >= speedPeriod)
            {
                speedVariationCounter = 0.0f;
                angle += .2f;
                // Debug.Log("Angle/Speed " + angle);
            }

            transform.RotateAround(target.transform.position, axis, angle);


         }

    public void Freezy()
    {

       

        Debug.Log("RUN FREEZY");

        speedVariationCounter += Time.deltaTime;


        if (speedVariationCounter >= speedPeriod)
        {
            speedVariationCounter = 0.0f;
            angle += .2f;
            // Debug.Log("Angle/Speed " + angle);
        }
        chrono += Time.deltaTime;
        chronoIntValue = (int)chrono;
        if (times == 0)
        {
            transform.RotateAround(target.transform.position, axis, angle);

            if (chronoIntValue == chronoValue1)
            {
                times = 1;
                chrono = 0f;

            }

        }
        if (times == 1)
        {
            transform.RotateAround(target.transform.position, axis, -angle);

            if (chronoIntValue == chronoValue2)
            {
                times = 0;
                chrono = 0f;
            }


        }




    
        }
        
    public void Lucky()
    {

        if(currentState == State.luky)
        {
            Debug.Log("RUN LUCKY");

            if (speedVariationCounter >= speedPeriod)
            {
                speedVariationCounter = 0.1f;
                angle += .2f;
                // Debug.Log("Angle/Speed " + angle);
            }
            transform.RotateAround(target.transform.position, axis, angle);
            robeTimer += Time.deltaTime;
            intRobeTimer = (int)robeTimer;
            if (intRobeTimer == robeTimerValue && Completed == false)
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, 90);
                Instantiate(robeObject, new Vector3(-1.8f, 1.94f, 0.56f), spawnRotation);
                Completed = true;
                robeTimer = 0;
            }
        }
    }
      
        
}
