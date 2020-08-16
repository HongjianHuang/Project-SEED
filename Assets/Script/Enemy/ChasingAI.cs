using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingAI : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 force; 
    //public Vector3 direction; 
    public float totalDistance;
    private EnemyAI enemyAI;
    private Rigidbody2D rb;
    //private float speed;
    
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody2D>();
        force = enemyAI.force;
        totalDistance = enemyAI.totalDistance;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //direction = enemyAI.direction;
        totalDistance = enemyAI.totalDistance;
        force = enemyAI.force;
        if (force.x >= 0.11f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        if (force.x < -0.11f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        if(totalDistance > 1f)
        {
            transform.position = transform.position + force;
        }
        
  
        
    }
}
