using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public float speed;

    public Transform[] waypoints;

    private Transform target;

    private int waypointIdx;
    public SpriteRenderer graphics;
    void Start()
    {
        waypointIdx = 0;
        target = waypoints[waypointIdx];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //When enemy at destination change target
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            waypointIdx = (waypointIdx + 1) % waypoints.Length;
            target = waypoints[waypointIdx];
            //Only work because two waypoints, should check direction
            graphics.flipX = !graphics.flipX;
        }
    }
}
