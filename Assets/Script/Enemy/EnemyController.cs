﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int partsNum;
    public int hitPoint; 




    void Start()
    {
        hitPoint = 2;

    }

    // Update is called once per frame
    
    private void Attack()
    {

    }
    private void AttchPoints()
    {
        
    }

    private void FixedUpdate()
    {
        if (hitPoint <= 0) gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "PlayerAttBox" )
        {
            hitPoint -= 1;
            Debug.Log("hit!");
        }
    }
}
