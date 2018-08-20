using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    #region Private fields
    private Transform target;
    private int waypointIndex = 0;
    private Enemy enemy;

    #endregion

    #region Private methods

    #region Unity methods
    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];
    }

    private void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }

    #endregion

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

    #endregion

}
