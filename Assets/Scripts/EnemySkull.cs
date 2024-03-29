using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySkull : MonoBehaviour
{
    public float Speed;
    public bool Ground = true;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public bool FacinRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        Ground = Physics2D.Linecast(GroundCheck.position, transform.position, GroundLayer);

        if (Ground == false)
        {
            Speed *= -1;
        }

        if (Speed > 0 && !FacinRight)
        {
            Flip();
        }
        else if (Speed < 0 && FacinRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        FacinRight = !FacinRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerLife>().LoseLife();
        }
    }


}