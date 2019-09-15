using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    //[Range(0,5f)][SerializeField] float walkSpeed = 1f;
    float currentSpeed = 1f;

    GameObject currentTarget;


    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetBool("isAttacking", false);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        Animator anim = GetComponent<Animator>();
        anim.SetBool("isAttacking", true);
        currentTarget = target;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {

        var damagedealer = collision.gameObject.GetComponent<DamageDealer>();
        if (damagedealer != null)
        {
            GetComponent<HealthManager>().Hit(damagedealer.GetDamage());
        }


    }

    public void StraikeCurrentTarget(float damage)
    {
        if (!currentTarget)
        {
            return;
        }
        HealthManager health = currentTarget.GetComponent<HealthManager>();
        if (health)
        {
            health.Hit(damage);
        }
    }

    private void OnDestroy()
    {
        LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }

    }
}
