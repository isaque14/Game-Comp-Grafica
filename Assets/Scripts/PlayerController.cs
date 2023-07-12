using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const float Speed = 2;
    public const float JumpForce = 6;
    public bool inFloor = true;
    private Rigidbody2D _rbPlayer;
    private SpriteRenderer _spritePlayer;
    private Animator _animatorPlayer;
    private GameController _GCPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _GCPlayer = GameController.GCInstance;
        _GCPlayer.Coins = 0;
        _animatorPlayer = GetComponent<Animator>();
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
            _animatorPlayer.SetBool("Walk", true);
            _spritePlayer.flipX = false;
        }
        else if (horizontalMoviment < 0)
        {
            _animatorPlayer.SetBool("Walk", true);
            _spritePlayer.flipX = true;
        }
        else
        {
            _animatorPlayer.SetBool("Walk", false);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            _animatorPlayer.SetBool("Jump", true);
            _rbPlayer.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            inFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            _animatorPlayer.SetBool("Jump", false);
            inFloor = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            _GCPlayer.Coins++;
            _GCPlayer.CoinsText.text = _GCPlayer.Coins.ToString();
        }
    }
}