using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemiesMoveSpeed = 5f;

    public float EnemiesMoveSpeed { get => enemiesMoveSpeed; set => enemiesMoveSpeed = value; }
    
    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetEnemiesMoveSpeed()
    {
        return enemiesMoveSpeed;
    }
}
