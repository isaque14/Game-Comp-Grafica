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
    private const int _LayerGround = 6;

    public AudioSource AudioS;
    public AudioClip[] Sonds;

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
            AudioS.clip = Sonds[3];
            AudioS.Play();
            _animatorPlayer.SetBool("Jump", true);
            _rbPlayer.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            inFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _LayerGround)
        {
            _animatorPlayer.SetBool("Jump", false);
            inFloor = true;
        }

        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            gameObject.transform.parent = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Coleta moedas
        if (collision.gameObject.tag == "Coins")
        {
            AudioS.clip = Sonds[0];
            AudioS.Play();
            Destroy(collision.gameObject);
            //_GCPlayer.Coins++;
            _GCPlayer.SetCoins(1);
            GameController.GCInstance.RefreshScreen();
        }

        //Mata inimigo com pulo
        if (collision.gameObject.tag == "Enemy")
        {
            AudioS.clip = Sonds[2];
            AudioS.Play();
            _rbPlayer.velocity = Vector2.zero;
            //_rbPlayer.AddForce(Vector2.up * 5, ForceMode2D.Impulse);   
            //collision.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            collision.gameObject.GetComponent<EnemySkull>().enabled = false;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Destroy(collision.gameObject, 1f);
        }

        //Mata inimigo com pulo
        if (collision.gameObject.tag == "Boss")
        {
            AudioS.clip = Sonds[2];
            AudioS.Play();
            _rbPlayer.velocity = Vector2.zero;
            //_rbPlayer.AddForce(Vector2.up * 5, ForceMode2D.Impulse);   
            //collision.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            collision.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            collision.gameObject.GetComponent<EnemySkull>().enabled = false;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Destroy(collision.gameObject, 1f);
        }
    }
}