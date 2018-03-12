﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    // Movement Speed
    public float speed = 2;

    // Current movement Direction
    Vector2 dir = Vector2.right;

    // Upwards push force
    public float upForce = 800;

    void FixedUpdate()
    {
        // Set the Velocity
        GetComponent<Rigidbody2D>().velocity = dir * speed;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name == "EnemyLeft" || coll.name=="EnemyRight" )
        transform.localScale = new Vector2(-1* transform.localScale.x,
                                                transform.localScale.y);

        // And mirror it
        dir = new Vector2( -1*dir.x, dir.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if (coll.gameObject.name == "BabyMario")
        {
           
            if (coll.contacts[0].point.y > transform.position.y)
            {
                // Play Animation
                GetComponent<Animator>().SetTrigger("Died");

                
                GetComponent<Collider2D>().enabled = false;

                coll.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * upForce);
                
                Invoke("Die", 5);
            }
            else
            {
               
                Destroy(coll.gameObject);
            }
        }
    }

    void flip()
    {
        Vector3 escala = transform.localScale;
        
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
