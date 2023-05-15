using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float Speed = 2;
    public const float JumpForce = 6;
    public bool inFloor = true;
    private Rigidbody2D _rbPlayer;
    private SpriteRenderer _spritePlayer;

    // Start is called before the first frame update
    void Start()
    {
        _spritePlayer = GetComponent<SpriteRenderer>();
        _rbPlayer = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(horizontalMoviment * Time.deltaTime * Speed, 0, 0);
        _rbPlayer.velocity = new Vector2(horizontalMoviment * Speed, _rbPlayer.velocity.y); 

        if (horizontalMoviment > 0)
        {
            _spritePlayer.flipX = false;
        }
        else if (horizontalMoviment < 0)
        {
            _spritePlayer.flipX = true;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            _rbPlayer.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            inFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            inFloor = true;
        }
    }
}
