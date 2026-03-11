using System;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Transform platform;
    private int currentWaypointIndex = 0;
    [SerializeField] private float platformSpeed;


    void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, platform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        
        platform.position = Vector2.MoveTowards(platform.position, 
            waypoints[currentWaypointIndex].transform.position, 
            Time.deltaTime * platformSpeed);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < waypoints.Length; i++)
        {
            float t = (float)i / (waypoints.Length - 1);
            Gizmos.color = Color.Lerp(Color.green, Color.red, t);
            Gizmos.DrawSphere(waypoints[i].transform.position, 0.1f);
        }
    }
}
