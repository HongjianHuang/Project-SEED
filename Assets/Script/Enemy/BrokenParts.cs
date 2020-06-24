using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenParts : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject enemyFoot;

    private Vector3 footPosition;

    private Vector3 randomPosition;
    private BoxCollider2D col;

    [Header("config")]
    [SerializeField] private float yForce;
    [SerializeField] private float xForce;
    [SerializeField] private float gravity;
    

    private void Start()
    {
        enemyFoot = GameObject.Find("EnemyFoot");
        footPosition = enemyFoot.transform.position;
        yForce = Random.Range(-10f, 50f);
        xForce = Random.Range(-10f, 20f);
        gravity = Random.Range(0.9f, 3.5f);
        randomPosition = new Vector3 (footPosition.x + Random.Range(-2f, 2f),
        footPosition.y + Random.Range(-2f, 2f), 0);
        col = gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false; 
        Debug.Log(footPosition);
        Debug.Log(randomPosition);
        Debug.Log(gameObject.transform.position);
        col.enabled = true;
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Wall")
        {
            Debug.Log("randomPosition "+randomPosition.y);
            Debug.Log("coll low point " + coll.bounds.min.y);
            if (randomPosition.y > coll.bounds.min.y)
            {
                float randomBounceBack = Random.Range(coll.bounds.min.y, coll.bounds.max.y);
                Debug.Log("randomBounceBack "+randomBounceBack);
                Debug.Log("self position "+transform.position.y);
                if (transform.position.y >= randomBounceBack) 
                {
                    
                    xForce = -xForce;

                }
            }
            //Debug.Log("in range of the wall");
            
            //Debug.Log(coll.bounds.min.y);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (gameObject.transform.position.y <= randomPosition.y)
        {
            enabled = false;
        }
        yForce -= gravity;
        transform.localPosition =  transform.localPosition + new Vector3(xForce*Time.deltaTime, yForce*Time.deltaTime,0);

            
    }
}
