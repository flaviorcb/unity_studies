using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
   
    [SerializeField] float health = 200f;
    [SerializeField] GameObject explosionEffect;


    public float GetHealth()
    {
        return health;
    }

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            var temp = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(temp, 1f);
        }
        
    }

   
}
