using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; 

public class NPCController : MonoBehaviour
{
    //find the distace, return float
    //Move to a Point
    public void FollowTarget(Path path, Rigidbody2D rb, float speed, float nextWayPointDistance, int currentWayPoint)
    {
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        Debug.Log("h");
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
            
        
    }
    //turnface
    //target distance


}
