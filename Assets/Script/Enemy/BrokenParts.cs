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
        yForce = Random.Range(-0.05f, 0.65f);
        xForce = Random.Range(-0.25f, 0.25f);
        gravity = Random.Range(0.045f, 0.01f);
        randomPosition = new Vector3 (footPosition.x + Random.Range(-2f, 2f),
        footPosition.y + Random.Range(-2f, 2f), 0);
        col = gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false; 
        Debug.Log(footPosition);
        Debug.Log(randomPosition);
        Debug.Log(gameObject.transform.position);
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (gameObject.transform.position.y <= randomPosition.y)
        {
            col.enabled = true;
            enabled = false;
        }
        yForce -= gravity;
        transform.localPosition =  transform.localPosition + new Vector3(xForce, yForce,0);

            
    }
}
