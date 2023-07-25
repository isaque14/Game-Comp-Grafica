using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GCInstance;
    public Text CoinsText;
    public int Coins;
    public const int NumberOfCoinsForNewLife = 100;

    public Text LifeText;
    public int Lives = 3;

    public Text TimeText;
    public float TimeCount;
    public bool TimeOver = false;

    public GameObject TextNextLevel;

    private void Update()
    {
        TimerCount();
    }

    void Awake()
    {
        if (GCInstance == null)
        {
            GCInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (GCInstance != this)
        {
            Destroy(gameObject);
        }
        RefreshScreen();
    }

    public void SetLives(int life)
    {
        Lives += life;
        
        if (Lives >= 0)
            RefreshScreen();
    }

    public void RefreshScreen()
    {
        CoinsText.text = Coins.ToString();
        LifeText.text = Lives.ToString();
        TimeText.text = TimeCount.ToString("F0");
    }

    void TimerCount()
    {
        TimeOver = false;

        if (!TimeOver && TimeCount > 0)
        {
            TimeCount -= Time.deltaTime;
            RefreshScreen();

            if(TimeCount <= 0)
            {
                TimeCount = 0;
                GameObject.Find("Player").GetComponent<PlayerLife>().LoadGameOver();
                TimeOver = true;
            }
        }
    }

    public void SetCoins(int coin)
    {
        Coins += coin;
        if (Coins >= NumberOfCoinsForNewLife)
        {
            Coins = 0;
            Lives += 1;
        }
    }
}
