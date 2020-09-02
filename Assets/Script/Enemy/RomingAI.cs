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
    public int moveNumber;
    public int moveCount; 
    public float roamingTimeGap = 3f;
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
        moveNumber = Random.Range(1,6);
        moveCount = 0;
    }

    private Vector2 roamingPosition()
    {
        
        float randomX = Random.Range(-6.0f, 6.0f);
        float randomY = Random.Range(-2.0f, 2.0f);
        Vector2 newPosition = transform.position;
        Vector2 result = Vector2.zero;
        if (moveCount >= moveNumber)
        {
            result = startPosition;
            moveCount = 0;
            moveNumber = Random.Range(1,6);
        }
        if (result == null)
        {
            result = transform.position;
        }
        else
        {
            result = new Vector2(newPosition.x + randomX, newPosition.y + randomY);
        }
        moveCount +=1;
        return result;
    }
    /*
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
    }*/
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
        //force = direction * speed * Time.deltaTime;
    
        if (Time.time >= currentTime)
        {
            currentTime += Time.time + roamingTimeGap;
            currentTargetPosition = roamingPosition();
            totalDistance = Vector2.Distance(rb.position, currentTargetPosition);
                //force = Vector2.zero;
        }
         

        
        if(distance > 1f)
        {
            force = direction * speed * Time.deltaTime;
            transform.position = transform.position + force;
        }
        
  
        
        
       

    }
}
