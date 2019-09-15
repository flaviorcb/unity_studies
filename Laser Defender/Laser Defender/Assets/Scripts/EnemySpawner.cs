using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    int startingWave = 0;
    [SerializeField] bool looping = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {


        foreach (Transform transform in waveConfig.GetWayPoints())
        {
            var newEnemy = Instantiate(
                waveConfig.EnemyPrefab,
                waveConfig.GetWayPoints()[0].transform.position,
                Quaternion.identity
            );

            newEnemy.GetComponent<EnemyPaths>().SetWaveConfig(waveConfig);


            yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns);
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (WaveConfig wave in waveConfigs)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(wave));
        }

    }


}
