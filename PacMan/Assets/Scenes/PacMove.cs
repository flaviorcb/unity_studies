using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMove : MonoBehaviour
{
    public float speed = 0.4f;

    Vector2 dest = Vector2.zero;
    Rigidbody2D myRigidBody;
    Collider2D myCollider;
    SpriteRenderer mySpriteRenderer;
    public LayerMask mask;
    public float distanciaRaioLaiser;


    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        myRigidBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, dest, speed);
        if (pos !=(Vector2) transform.position)
        {
            //Debug.Log("posicao inicial: " + transform.position + "posicao destin: " + pos);
            Debug.Log("Vector right " + Vector2.right);
        }
        myRigidBody.MovePosition(pos);

        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.W) && valido(Vector2.up))
            {
                dest = (Vector2)transform.position + Vector2.up;

                //mySpriteRenderer.flipX = false;
                //transform.rotation = Quaternion.identity;
                //transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            if (Input.GetKey(KeyCode.D) && valido(Vector2.right))
            {
                dest = (Vector2)transform.position + Vector2.right;

                mySpriteRenderer.flipX = false;
                //transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.A) && valido(Vector2.left))
            {
                dest = (Vector2)transform.position + Vector2.left;

                mySpriteRenderer.flipX = true;
                //transform.rotation = Quaternion.identity;
            }
            if (Input.GetKey(KeyCode.S) && valido(Vector2.down))
            {
                dest = (Vector2)transform.position + Vector2.down;

                //mySpriteRenderer.flipX = false;
                //transform.rotation = Quaternion.identity;
                //transform.rotation = Quaternion.Euler(0, 0, -90);
            }

        }

       
    }

   

    // Update is called once per frame
    void Update()
    {

    }

    bool valido(Vector2 direction)
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        
        return (hit.collider == myCollider);
    }
}
