using Pathfinding;
using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Seeker))]

public class Enemy1AI : MonoBehaviour {

    //What it is chasing
    public Transform target;

    //Times per second we will update path
    public float updateRate = 2f;

    private Seeker seeker;
    private Rigidbody2D rb;

    //The Calculated Path:

    public Path path;

    //The AI's speed per second
    public float speed = 300f;
    public ForceMode2D fMode;
    
    [HideInInspector]
    public bool pathHasEnded = false;

    //The maximum distance from AI to waypoint, to continue to next waypoint
    public float nextWaypointDistance = 3;

    //Waypoint we are currently moving towards
    private int currentWaypoint = 0;

    void Start ()
    {

        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if(target == null)
        {
            Debug.LogError("No Player found");
            return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath()
    {
        if(target == null)
        {
            //TODO: insert player search here
            yield return false;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);
        
        yield return new WaitForSeconds(1f / updateRate);

        StartCoroutine(UpdatePath());

    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Path had an error:" + p.error);
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }

    }

    void FixedUpdate()
    {
        if(target == null)
        {
            return;
        }

        if(path == null)
        {

            return;
        }

        if(currentWaypoint >= path.vectorPath.Count)
        {
            if (pathHasEnded)
            {
                return;
            }

            Debug.Log("End of path reached.");
            pathHasEnded = true;

        }
        pathHasEnded = false;

        //Directions to next waypoint
        Vector3 dir = ( path.vectorPath[currentWaypoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        //Move the AI
        rb.AddForce(dir, fMode);

        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
        if (dist < nextWaypointDistance)
        {
            currentWaypoint++;
            return;
        }
    }
}
