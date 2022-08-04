using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCoinManager : MonoBehaviour
{
    #region Singleton:GameCoinManager
    public static GameCoinManager Instance;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    #endregion


    public int Coins;
    string Coins_value = "coinsvalue";
   

    private void Start()
    {
        Coins = PlayerPrefs.GetInt(Coins_value);
        Debug.Log(Coins);

    }

    public void UseCoins(int amount)
    {
        Coins -= amount;
        GameStat.gameStat.Coins = Coins;
        PlayerPrefs.SetInt(Coins_value, Coins);
        Debug.Log(Coins);
    }

    public bool HasEnoughCoins(int amout)
    {

        return (Coins >= amout);
    }

    public int ReturnCoins()
    {
        return Coins;
    }


}
