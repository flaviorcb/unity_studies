using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    Coroutine routine;
    [SerializeField] Attacker[] enemy;
    [SerializeField]private float minSpawnDelay = 1;
    [SerializeField]private float maxSpawnDelay = 5;

    // Start is called before the first frame update
    void Start()
    {
        routine = StartCoroutine(SpawnAtackers());

    }



    private IEnumerator SpawnAtackers()
    {
        while (true)
        {
            int index = UnityEngine.Random.Range(0, enemy.Length);
            float t = UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(t);
            Attacker newAttacker = Instantiate(enemy[index], transform.position, transform.rotation) as Attacker;
            newAttacker.transform.parent = transform;
            //FindObjectOfType<SpawnerManager>().addAttacker();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (spawn == false)
        {
            StopCoroutine(routine);
        }

    }

    public void StopSpawning()
    {
        spawn = false;
    }

   
}
