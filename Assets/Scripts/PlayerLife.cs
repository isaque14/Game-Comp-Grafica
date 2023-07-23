using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public bool alive = true;
    private const int TimeLevel = 120;
    private const int BaseLifes = 3;

    void Start()
    {
        GameController.GCInstance.RefreshScreen();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLife()
    {
        if (alive)
        {
            alive = false;
            gameObject.GetComponent<Animator>().SetTrigger("Dead");
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            gameObject.GetComponent<Animator>().SetBool("Jump", false);
            GameController.GCInstance.SetLives(-1);

            if (GameController.GCInstance.Lives > 0)
            {
                Invoke("LoadScene", 1f);
            }
            else
            {
                Invoke("LoadGameOver", 2f);
                GameController.GCInstance.Lives = BaseLifes;
            }
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Fase 1");
        GameController.GCInstance.TimeCount = TimeLevel;
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

}