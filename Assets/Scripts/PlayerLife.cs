using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public bool alive = true;
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
                Debug.Log("Game Over");
                GameController.GCInstance.Lives = 0;
            }
        }
    }
    void LoadScene()
    {
        SceneManager.LoadScene("Fase 1");
    }

}
