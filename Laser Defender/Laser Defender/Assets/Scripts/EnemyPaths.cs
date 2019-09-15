using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaths : MonoBehaviour
{
    [SerializeField]WaveConfig waveConfig;
    List<Transform> wayPoints;
    
    int actualWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        actualWayPoint = 0;
        transform.position = wayPoints[actualWayPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;

    }

    private void Move()
    {
        float step = waveConfig.MoveSpeed * Time.deltaTime;      
        Vector2 newPos =  Vector2.MoveTowards(transform.position, wayPoints[actualWayPoint].position, step);

        if (transform.position.Equals(newPos))
        {
            actualWayPoint++;
            if(actualWayPoint >= wayPoints.Count)
            {
                Destroy(gameObject);
            }
        }

        transform.position = newPos;
        
    }
}
