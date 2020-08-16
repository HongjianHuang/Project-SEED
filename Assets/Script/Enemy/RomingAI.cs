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
    public Vector3 direction;
    public float speed;

    public float roamingTimeGap = 0.5f;
    private float currentTime; 
    private Vector3 force; 
    




    void Start()
    {
        force = Vector3.zero;
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
        if (randomX < 0f && randomX > -5.0f) randomX = -5.0f;
        if (randomX > 0f && randomX < 5.0f) randomX = 5.0f;
        if (randomY > 0f && randomY < 1.5f) randomY = 1.5f;
        if (randomY < 0f && randomY > -1.5f) randomY = -1.5f;
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
    public float SpeedAlter()
    {
        float angleBetween = Vector2.Angle(Vector2.right, direction);
        float numerator = Mathf.Abs(90f - angleBetween);
        float alterFactor = enemyAI.maxSpeedRange*(numerator/90f);
        if (numerator/90f < 1)
        {
           
            return alterFactor;
        }
        
        return enemyAI.maxSpeedRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (force.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        if (force.x < -0.01f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
    }
    void FixedUpdate()
    {
        direction = (currentTargetPosition - rb.position).normalized;
        distance = Vector2.Distance(rb.position, currentTargetPosition);
        speed = enemyAI.minSpeed + SpeedAlter();
        force = direction * speed * Time.deltaTime;
        if(distance <= 0.3)
        {
            if (Time.time >= currentTime)
            {
                currentTime += Time.time + roamingTimeGap;
                currentTargetPosition = roamingPosition();
                totalDistance = Vector2.Distance(rb.position, currentTargetPosition);
                force = Vector2.zero;
            }      
        }
        if (totalDistance > 1f)
        {
            transform.position = transform.position + force;
        }
        
        
       

    }
}
