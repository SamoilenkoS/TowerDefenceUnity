﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private int waypointIndex = 0;
    private Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex == Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        ++waypointIndex;
        target = Waypoints.waypoints[waypointIndex];
    }
    private void EndPath()
    {
        --PlayerStats.Lives;
        Destroy(gameObject);
    }
}
