using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public const float Timefase = 120f;
    public bool lastFase;

    public AudioClip Finish;
    public AudioSource AudioS;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameController.GCInstance.TextNextLevel.SetActive(true);
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Stop();
            collision.GetComponent<PlayerController>().enabled = false;
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponent<Animator>().SetBool("Walk", false);
            collision.GetComponent<Animator>().Play("Player_Idle");
            GetComponent<AudioSource>().clip = Finish;
            GetComponent<AudioSource>().Play();
            Invoke("NextScenes", 5f);
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
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            GameController.GCInstance.TextNextLevel.SetActive(false);
            GameController.GCInstance.TimeCount = Timefase;
            GameObject.Find("MusicPlayer").GetComponent<AudioSource>().Play();
        }
    }
}
