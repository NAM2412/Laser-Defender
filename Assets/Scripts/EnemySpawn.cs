using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] WaveConfig currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }
    private void SpawnEnemies()
    {
        for(int i = 0; i < currentWave.GetEnemyCount(); i++) 
        {
            Instantiate(currentWave.GetEnemyPrefab(i++),
                        currentWave.GetStartingWayPoint().position,
                        Quaternion.identity, transform);
        }
        
    }
}
