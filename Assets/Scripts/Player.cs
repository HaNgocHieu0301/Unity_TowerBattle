using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private bool isGround = true;

    private string WALK_ANIMATION = "walk";
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyBoard();
        AnimatePlayer();
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }
    void PlayerMoveKeyBoard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * jumpForce * Time.deltaTime;

    }

    void AnimatePlayer()
    {
        if(movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }else if(movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            isGround = false;
            Debug.Log("Jump Pressed");
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGround = true;
        }
        //destroy nhân vật khi va chạm với monster
        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG)){
            Destroy(gameObject);
        }
        //collider2D ở đây có thể sử dụng trực tiếp method CompareTag mà k cần qua gameObject
        //khác với collision2D phải thông qua
    }
}
