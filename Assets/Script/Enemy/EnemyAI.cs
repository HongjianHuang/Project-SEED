using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed = 200;

    public float nextWayPointDistance = 3f;
    public float triggerDistance = 10f; 
    private Path path;
    private int currentWayPoint = 0;
    private bool reachedEndOfPath = false; 
    //private NPCController nController;
    private float distance; 

    private Seeker seeker;
    private Rigidbody2D rb;
    private Vector2 roamingP;
    private WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
    void Start()
    {
        //nController = FindObjectOfType<NPCController>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
    }
    void UpdatePath()
    {
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    private Vector2 roamingPosition()
    {
        
        float randomX = Random.Range(-5.0f, 5.0f);
        float randomY = Random.Range(-0.5f, 5.0f);
        Vector2 result = new Vector2(randomX,randomY);
        if (result == null)
        {
            result = transform.position;
        }
        return result;
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) return; 
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return; 
        }
        else
        {
            reachedEndOfPath = false;
        }
        //Move
        //FindObjectOfType<NPCController>().FollowTarget(path, rb, speed, nextWayPointDistance, currentWayPoint);
        //turn face;
        //set trigger distance
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
            

    }
}
