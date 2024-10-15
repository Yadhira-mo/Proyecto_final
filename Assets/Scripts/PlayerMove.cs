using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    // salto doble
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;
    Rigidbody2D rb2d;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    // salto mas lento 
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;

    //animacion
    public Animator animator;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //private void Update()
    
   
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right") )
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }

        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

        }



        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            animator.SetBool("Run", false);
        }

        if (Input.GetKey("up") ) //|| Input.GetKey("space")
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("up") ) //|| Input.GetKey("space")
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb2d.velocity = new Vector2(rb2d.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
            
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);

        }
        if (rb2d.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        }
        else if (rb2d.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }

       

        if (betterJump)
        {
            if (rb2d.velocity.y < 0)
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if (rb2d.velocity.y > 0 && !Input.GetKey("up") ) //|| Input.GetKey("space")
            {
                rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }


    }
}
