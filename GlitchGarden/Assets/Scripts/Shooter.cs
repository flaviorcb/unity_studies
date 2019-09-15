using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    [SerializeField] private AttackerSpawner myLaneSpawner;
    [SerializeField] private int lane = 1;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "ProjectileParent";


    private void Start()
    {
        CreateProjectileParent();
        SetLaneSpawner();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        Animator anim = GetComponent<Animator>();

        if (IsAttackerInLane())
        {
            anim.SetBool("isAttacking", true);
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            Debug.Log("spawner.y = " + spawner.transform.position.y + " Cactus Lane = " + lane);
            bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - lane) <= Mathf.Epsilon;
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
                break;
            }
        }

    }

    public void Fire()
    {
       GameObject newProjectile =  Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        newProjectile.transform.parent = projectileParent.transform;
    }




    private bool IsAttackerInLane()
    {
        return myLaneSpawner.transform.childCount > 0;
    }

    public void SetLane(float lane)
    {
        this.lane = Mathf.RoundToInt(lane);
    }
}
