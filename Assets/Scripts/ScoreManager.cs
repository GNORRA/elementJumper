using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ScoreManager : MonoBehaviour
{


    public static ScoreManager scoreManager;

    public  TMP_Text healthText;
    public  TMP_Text coinText;
    public  TMP_Text scoreText;
    public TMP_Text finalscoreValue;





    public int health;
    public int colliderValue;
   [SerializeField] public float coin;
    float finalCoin;
    public int score;
    public int lastScore;

    string Coins_value = "coinsvalue";
    string Score_value = "scorevalue";
    string Health_value = "healthvalue";


    public Animator heartAnim;

    void Awake()
    {
        scoreManager = this;
        health = PlayerPrefs.GetInt(Health_value);
        finalCoin = PlayerPrefs.GetInt(Coins_value);
        lastScore = PlayerPrefs.GetInt(Score_value);
        heartAnim.SetTrigger("heartBeat");
        
    }

    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
#pragma warning disable CS1717 // Assignation effectuée à la même variable
        lastScore = score;
        if(lastScore > score)
        {
            PlayerPrefs.SetInt(Score_value, lastScore);
        }
        else
        {
            PlayerPrefs.SetInt(Score_value, score);
        }
#pragma warning restore CS1717 // Assignation effectuée à la même variable
        if (score >= 1)
        {
            coin += .00001f;
            finalCoin = coin;
           // Debug.Log("Coin cauri : " + finalCoin);

            if ((score % 2) * 2 == 0)
            {
                coin += .0001f;
                finalCoin = coin;

            }
        }
        


#pragma warning disable CS1717 // Assignation effectuée à la même variable
        colliderValue = colliderValue;
#pragma warning restore CS1717 // Assignation effectuée à la même variable

#pragma warning disable CS1717 // Assignation effectuée à la même variable
       PlayerPrefs.SetInt(Health_value, health);
        
#pragma warning restore CS1717 // Assignation effectuée à la même variable

        healthText.text = health.ToString();
        coinText.text = coin.ToString();
        scoreText.text = lastScore.ToString();


       
       // Debug.Log("Score : " + score);
      //  Debug.Log("Health : " + health);

        if(health <= 0)
        {
            //CameraRotator.cameraRotator.animRotateCamera = true;
            healthText.text = "0";
            PlayerPrefs.SetInt(Health_value, 0);
            finalscoreValue.text = lastScore.ToString();
            GameMenuManager.gameMenuManager.gameMenuState = 1; // Active In Game Menu Panel
           // Elevator.elevator.speed = 0f;
            PlayerPrefs.SetFloat(Coins_value, finalCoin);
            coinText.text = ""+finalCoin;
            
           // coin =.000f;
        }

      

    }


  
}
