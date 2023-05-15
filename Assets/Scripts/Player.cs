using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const float Speed = 4;
    private Rigidbody2D _rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(horizontalMoviment * Time.deltaTime * Speed, 0, 0);
        _rbPlayer.velocity = new Vector2(horizontalMoviment * Speed, _rbPlayer.velocity.y);
    }
}
