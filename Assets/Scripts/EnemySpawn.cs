using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    WaveConfig currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
    private IEnumerator SpawnEnemiesWaves()
    {
        do
        {
            foreach(WaveConfig wave in waveConfigs) 
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++) 
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            }
        yield return new WaitForSeconds(timeBetweenWaves);       
        } while (isLooping);
        
    }
}
