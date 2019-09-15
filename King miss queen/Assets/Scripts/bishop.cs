using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bishop : MonoBehaviour
{
    
    public Vector2 velocity;
    Rigidbody2D myRigidbody2D;

    

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.velocity = velocity * Time.deltaTime;

    }

    // Update is called once per frame
    void Update()
    {
       


    }

   
}
