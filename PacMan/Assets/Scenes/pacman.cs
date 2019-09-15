using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacman : MonoBehaviour
{

    Rigidbody2D myRigidBody;
    SpriteRenderer mySpriteRenderer;
    // Start is called before the first frame update
    [SerializeField] private float maxVelocity;
    
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            myRigidBody.velocity = Vector2.right * maxVelocity;
            transform.rotation = Quaternion.identity;
            mySpriteRenderer.flipX = false;
            Debug.Log("D");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            myRigidBody.velocity = Vector2.left * maxVelocity;
            transform.rotation = Quaternion.identity;  
            mySpriteRenderer.flipX = true;
            
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            myRigidBody.velocity = Vector2.up * maxVelocity;

            mySpriteRenderer.flipX = false;
            transform.rotation = Quaternion.identity;  
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            myRigidBody.velocity = Vector2.down * maxVelocity;
            mySpriteRenderer.flipX = false;
            transform.rotation = Quaternion.identity;  
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
