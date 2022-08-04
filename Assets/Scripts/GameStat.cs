using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStat : MonoBehaviour
{
    public static GameStat gameStat;


    [SerializeField] public float Coins;
    [SerializeField] public int Score;
    [SerializeField] public int Health;

    [SerializeField] public Text textCoins;
    [SerializeField] public Text textScore;
    [SerializeField] public Text textHealth;

    string Coins_value = "coinsvalue";
    string Score_value = "scorevalue" ;
    string Health_value = "healthvalue";
    // Start is called before the first frame update

    private void Awake()
    {
        gameStat = this;
    }
    void Start()
    {

        Coins = PlayerPrefs.GetFloat(Coins_value);
        Score = PlayerPrefs.GetInt(Score_value);
       // Health = PlayerPrefs.GetInt(Health_value);
       // Coins = PlayerPrefs.GetInt(Coins_value);
      

    }


    // Update is called once per frame
    void Update()
    {


        PlayerPrefs.SetInt(Health_value, Health);

        PlayerPrefs.SetFloat(Coins_value, Coins);

        Coins = PlayerPrefs.GetFloat(Coins_value);
        Score = PlayerPrefs.GetInt(Score_value);
        Health = PlayerPrefs.GetInt(Health_value);

        textCoins.text = "" + Coins;

        textScore.text = "" + Score;

        textHealth.text = "" + Health;

      

    }

   
}
