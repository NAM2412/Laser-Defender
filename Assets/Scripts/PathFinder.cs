using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawn enemySpawn;
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;


    void Awake() 
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }
    void Start()
    {
        waveConfig = enemySpawn.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints(); // lấy các điểm waypoint
        transform.position = waypoints[waypointIndex].position; // cho vị trí của Dassault == vị trí đầu tiên waypoints(list)
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float deltaSpeed = waveConfig.MoveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, deltaSpeed);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
