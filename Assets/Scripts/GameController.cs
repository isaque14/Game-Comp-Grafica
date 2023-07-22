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
    }
}
