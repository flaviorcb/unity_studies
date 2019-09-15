using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    public GameObject[] paths;
    public GameObject enemyPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateEnemies();
        
    }

    private void CreateEnemies()
    {
        foreach (GameObject path in paths)
        {
            Instantiate(enemyPrefab, path.transform.GetChild(0).position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
