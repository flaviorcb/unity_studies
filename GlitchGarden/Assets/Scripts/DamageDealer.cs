using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float damage = 100f;
    

    public float GetDamage()
    {
        return damage;
    }
}
