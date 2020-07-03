using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingAI : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 force; 
    public Vector2 direction; 
    private EnemyAI enemyAI;
    private Rigidbody2D rb;
    private float speed;
    
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody2D>();
        direction = enemyAI.direction;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //direction = enemyAI.direction;

        force = enemyAI.force;
        if (force.x >= 0.11f)
        {
            transform.localScale = new Vector3(-1f,1f,1f);
        }
        if (force.x < -0.11f)
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        
        rb.AddForce(force);
    }
}
