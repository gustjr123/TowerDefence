using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex;
    private float minDistance = 0.1f;
    private int lastWaypointIndex;
    private float movementSpeed = 1.0f;
    float timer;

    void Start()
    {
        targetWaypoint = waypoints[targetWaypointIndex];
    }

    void Update()
    {
        timer += Time.deltaTime;
        Vector3 target = new Vector3(2.5f, 0f, -14f);
        Vector3 target2 = new Vector3(0, 0, -10f);
        //float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        //CheckDistanceToWaypoint(distance);

        if (timer > 2.95)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
        }

        if (timer > 8)
        {
            transform.position = Vector3.MoveTowards(transform.position, target2, 0.125f);
        }
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
