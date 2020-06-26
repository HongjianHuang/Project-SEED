using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingAI : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector2 force; 

    private EnemyAI enemyAI;
    private Rigidbody2D rb;
    
    void Start()
    {
        enemyAI = GetComponent<EnemyAI>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        force = enemyAI.force;
        rb.AddForce(force);
    }
}
