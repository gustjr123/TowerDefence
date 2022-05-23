using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex;
    private float minDistance = 0.1f;
    private int lastWaypointIndex;

    private float movementSpeed = 1.0f;

    void Start()
    {
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    void Update()
    {
        //float movementStep = movementSpeed * Time.deltaTime;
        Vector3 target = new Vector3(2.5f, 0f, -14f);
        //float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        //CheckDistanceToWaypoint(distance);

        transform.position = Vector3.MoveTowards(transform.position, target, 1f);
    }
    /*
    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }
    
    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }
    */
}
