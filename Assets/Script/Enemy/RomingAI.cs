using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class RomingAI : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 currentTargetPosition;
    private Rigidbody2D rb;
    private EnemyAI enemyAI;
    public float distance;
    public float totalDistance; 
    public Vector2 startPosition;

    public float roamingTimeGap = 0.5f;
    private float currentTime; 
    private Vector2 force; 
    




    void Start()
    {
        force = Vector2.zero;
        currentTime = 0.0f;
        startPosition = transform.position;
        currentTargetPosition = roamingPosition();
        
        enemyAI = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody2D>();
        totalDistance = Vector2.Distance(rb.position, currentTargetPosition);
    }

    private Vector2 roamingPosition()
    {
        
        float randomX = Random.Range(-6.0f, 6.0f);
        float randomY = Random.Range(-2.0f, 2.0f);
        Vector2 result = new Vector2(startPosition.x + randomX, startPosition.y + randomY);
        if (result == null)
        {
            result = transform.position;
        }
        return result;
    }
    public bool ChackRayCast(Rigidbody2D rb, float distance, int layerMask)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, -Vector2.up, distance, layerMask);
        RaycastHit2D hit1 = Physics2D.Raycast(rb.position, Vector2.up, distance, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(rb.position, -Vector2.right, distance, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(rb.position, Vector2.right, distance, layerMask);
        if (hit.collider != null||hit1.collider!= null||hit2.collider!= null||hit3.collider != null)
        {
            return true;
        }
        else return false; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (currentTargetPosition - rb.position).normalized;
        distance = Vector2.Distance(rb.position, currentTargetPosition);
        force = direction * enemyAI.speed * Time.deltaTime * (distance/totalDistance);
        if(distance <= 0.3)
        {
            if (Time.time >= currentTime)
            {
                Debug.Log("waiting");
                currentTime += Time.time + roamingTimeGap;
                currentTargetPosition = roamingPosition();
                totalDistance = Vector2.Distance(rb.position, currentTargetPosition);
                force = Vector2.zero;
            }      
        }
        rb.AddForce(force);
        
       

    }
}
