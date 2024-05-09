using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 10f;
    [SerializeField]
    public float jumpForce = 11f;

    private float movementX;

    [SerializeField]
    private Rigidbody2D mybody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_Animation = "Walk";

    private bool isGrounded = true;

    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";


    // Start is called before the first frame update
    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimaterPlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard()// ÒÆ¶¯
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    } 
    void AnimaterPlayer()// ¸úËæ·½Ïò×ªÍ·
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_Animation, true);
            sr.flipX = false;
        }
        else if(movementX < 0)
        {
            anim.SetBool(WALK_Animation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_Animation, false);
        }
    }
    void PlayerJump()// ÌøÔ¾
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            anim.SetBool("Jump", true);
            mybody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ÌøÔ¾
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            anim.SetBool("Jump", false);
        }
        // Íæ¼Ò´¥Åö¹ÖÎïËÀÍö
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
