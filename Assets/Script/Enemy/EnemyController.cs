using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int partsNum;
    public int hitPoint; 

    public bool bodyExposed;




    private void Awake()
    {
        hitPoint = 2;
        partsNum = Random.Range(0,7);
        bodyExposed = true;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (hitPoint <= 0) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "PlayerAttBox" )
        {
            if (bodyExposed)
            {
                hitPoint -= 1;
                Debug.Log("hit!");
            }
            
        }
    }
}
