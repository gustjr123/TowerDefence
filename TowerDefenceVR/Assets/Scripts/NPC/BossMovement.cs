using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
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
        Vector3 target = new Vector3(0, 0, -14);
        transform.position = Vector3.MoveTowards(transform.position, target, 0.00025f);
    }
}
