using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GCInstance;
    public Text CoinsText;
    public int Coins;

    public Text LifeText;
    public int Lives = 3;

    public Text TimeText;
    public float TimeCount;
    public bool TimeOver = false;


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
                GameObject.Find("Player").GetComponent<PlayerLife>().LoseLife();
                TimeOver = true;
            }
        }
    }

    public void SetCoins(int coin)
    {
        Coins += coin;
        if (Coins >= 25)
        {
            Coins = 0;
            Lives += 1;
        }
    }
}
