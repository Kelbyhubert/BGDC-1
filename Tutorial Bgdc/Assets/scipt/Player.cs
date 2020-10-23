using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //bdasdaxdasdafatgagafaa
    //test
    [SerializeField] float speed = 15f;
    [SerializeField] Rigidbody2D rb;
    Animator anim;
    float jumpspeed = 30f;
    CapsuleCollider2D col;
    BoxCollider2D boxcol;
    float startgravity;
    public bool dash;
    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider2D>();
        boxcol = GetComponent<BoxCollider2D>();
        startgravity = rb.gravityScale;
    }

    // Update is called once per frame

    private void Update()
    {
        if (!alive) return;
        
        bool mask = boxcol.IsTouchingLayers(LayerMask.GetMask("Ground"));
        
        anim.SetBool("Land", mask);
        if (Input.GetKeyDown(KeyCode.Q) && mask && !col.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            dash = true;
            rolling();
        }
        if(Input.GetKeyUp(KeyCode.Q))
        {
            dash = false;
        }
       
        if (!dash)
        {
            jump(mask);
            Movement();
            Flip();
            climb();
        }
        die();
        
    }
   


    private void Movement()
    {

        
            var Horizontal = Input.GetAxis("Horizontal");
            var PlayerVelocity = new Vector2(Horizontal * speed, rb.velocity.y);
        
            rb.velocity = PlayerVelocity;
        
        

            bool HSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
            anim.SetBool("IsWalking", HSpeed);
    }
    private void jump(bool mask)
    {
        if (Input.GetButtonDown("Jump") && mask)
        {
         
            var jump = new Vector2(0f, jumpspeed);
            rb.velocity += jump;
            
        }
    }
    private void Flip()
    {
        bool flip = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (flip)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }
    void climb()
    {
        if (!col.IsTouchingLayers(LayerMask.GetMask("Ladder"))) {
            anim.SetBool("Climb", false);
            rb.gravityScale = startgravity;
            return;
        }
        
            var Climb = Input.GetAxis("Vertical");
            var Climbpos = new Vector2(rb.velocity.x, Climb * 10f);
            rb.velocity = Climbpos;
        rb.gravityScale = 0f;

        bool Climbspeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
        anim.SetBool("Climb", Climbspeed);
        
    }
    private void rolling()
    {
        anim.SetTrigger("IsRolling");
        
        rb.velocity = new Vector2( 20f * transform.localScale.x, rb.velocity.y);
 
    }
    void die()
    {
        if (col.IsTouchingLayers(LayerMask.GetMask("Enemy","Trap")))
        {
            anim.SetTrigger("die");
            rb.velocity = new Vector2(-10f * transform.localScale.x, 10f);
            alive = false;
            FindObjectOfType<Game_config>().GameLife();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (boxcol.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Destroy(collision.gameObject);
            rb.velocity = new Vector2(0f, 20f);
        }

        
    }

}
