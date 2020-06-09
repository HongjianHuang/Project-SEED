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
    public Vector2 startPosition;




    void Start()
    {
        startPosition = transform.position;
        currentTargetPosition = roamingPosition();
        enemyAI = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody2D>();
    }

    private Vector2 roamingPosition()
    {
        
        float randomX = Random.Range(-3.0f, 3.0f);
        float randomY = Random.Range(-1.0f, 1.0f);
        Vector2 result = new Vector2(startPosition.x + randomX, startPosition.y + randomY);
        if (result == null)
        {
            result = transform.position;
        }
        return result;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (currentTargetPosition - rb.position).normalized;
        Vector2 force = direction * enemyAI.speed * Time.deltaTime;
        distance = Vector2.Distance(rb.position, currentTargetPosition);
        rb.AddForce(force);
        if(distance <= 0.05)
        {
            currentTargetPosition = roamingPosition();
        }

    }
}
