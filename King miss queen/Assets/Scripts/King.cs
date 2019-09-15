using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    Rigidbody2D myRigidBody;
    SpriteRenderer mySpriteRenderer;
    Animator myAnimator;
    public float maxVelocity;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "queen")
        {
            myAnimator.SetBool("levelCompleted", true);

        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            myRigidBody.velocity = Vector2.right * maxVelocity;
            mySpriteRenderer.flipX = false;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            myRigidBody.velocity = Vector2.left * maxVelocity;
            mySpriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            myRigidBody.velocity = Vector2.down * maxVelocity;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidBody.velocity = Vector2.up * maxVelocity;
        }
    }
}
