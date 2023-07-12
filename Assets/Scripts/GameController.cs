using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController GCInstance;
    public Text CoinsText;
    public int Coins;

    void Awake()
    {
        if (GCInstance == null)
        {
            GCInstance = this;
        }
        else if (GCInstance != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
