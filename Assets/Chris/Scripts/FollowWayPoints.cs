using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWayPoints : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;

    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float rotationSpeed = 1.0f;
    private void Awake()
    {
        transform.position = waypoints[currentWaypointIndex].position;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // Rotate towards 
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        // roate smooth
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
}
