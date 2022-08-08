using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerProgress : MonoBehaviour
{

    public static PowerProgress powerProgress;
   
    private float currentValue = 0f;
   
    public Slider slider;
   // public Text displayText;
  

    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
            slider.value = currentValue;
          //  displayText.text = (slider.value * 100).ToString("0.00") + "%";
        }
    }

    //-------------------------- intitaliz -----------------------
    void Start()
    {
        CurrentValue = 0.0f;
        powerProgress = this;
    }

    void Update()
    {

        if (CurrentValue >= slider.maxValue)
        {

            Debug.Log("GAIN POWER");
            //CurrentValue += 0.125f;
            //Give air capsul to decrease gravity
            //
        }
        else
        {
            CurrentValue += 0.0100f * Time.deltaTime;
        }
    }
}
