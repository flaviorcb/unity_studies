using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        KillPawn();
        
    }

    private void KillPawn()
    {
        Destroy(gameObject);
    }
}
