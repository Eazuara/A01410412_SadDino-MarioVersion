using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    public float maxVel = 5f;
    public float yJumpForce = 300f;

    private bool isjumpling = false;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 jumpforce;
    private bool movingRight = true;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        jumpforce = new Vector2(0, 0);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    

    //we update horizontal speed
    float v = Input.GetAxis("Horizontal");
        Vector2 vel = new Vector2(0, rb.velocity.y);

        v *= maxVel;

        vel.x = v;

        rb.velocity = vel;

        //we change animations if needed
        if (v != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        //if player jumps
        if (Input.GetAxis("Jump") > 0.01f)
        {
            if (!isjumpling)
            {
                if (rb.velocity.y == 0)
                {
                    isjumpling = true;
                    jumpforce.x = 0f;
                    jumpforce.y = yJumpForce;
                    rb.AddForce(jumpforce);
                }
            }
        }
        else
        {
            isjumpling = false;
        }
        if (movingRight && v < 0)
        {
            movingRight = false;
            Flip();
        }
        else if (!movingRight && v > 0)
        {
            movingRight = true;
            Flip();
        }
    }
    private void Flip()
    {
        var s = transform.localScale;
        s.x *= -1;
        transform.localScale = s;
    }
}