using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public const float Timefase = 120f;
    public bool lastFase;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.GCInstance.TextNextLevel.SetActive(true);
            Invoke("NextScenes", 1f);
        }
    }

    void NextScenes()
    {
        if (lastFase)
        {
            SceneManager.LoadScene("Menu");
            GameController.GCInstance.TextNextLevel.SetActive(false);
            GameController.GCInstance.TimeCount = 0;
            GameController.GCInstance.Lives = 0;
            GameController.GCInstance.Coins = 0;
            GameController.GCInstance.RefreshScreen();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameController.GCInstance.TextNextLevel.SetActive(false);
            GameController.GCInstance.TimeCount = Timefase;
        }
    }
}
