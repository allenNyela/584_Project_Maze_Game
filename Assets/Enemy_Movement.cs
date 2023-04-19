using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy_Movement : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 3f;
    public float nextWaypointDistance = 3f;
    public float pathUpdateInterval = 0.5f; // Interval in seconds to update the path

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    private Seeker seeker;
    private Rigidbody2D rb;
    private float lastPathUpdateTime;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        lastPathUpdateTime = -pathUpdateInterval;
    }

    void Update()
    {
        if (Time.time - lastPathUpdateTime >= pathUpdateInterval)
        {
            if (seeker.IsDone() && target != null)
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
                lastPathUpdateTime = Time.time;
            }
        }

        if (path == null || reachedEndOfPath)
            return;

        float distanceToWaypoint = Vector3.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distanceToWaypoint < nextWaypointDistance)
        {
            currentWaypoint++;
            reachedEndOfPath = currentWaypoint >= path.vectorPath.Count;
        }

        if (!reachedEndOfPath)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;

            rb.AddForce(force);
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
