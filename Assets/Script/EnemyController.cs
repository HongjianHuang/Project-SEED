using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int partsNum;
    private int hitPoint; 

    void Start()
    {
        hitPoint = 2;
    }

    // Update is called once per frame
    private void Attack()
    {

    }

    private void FixedUpdate()
    {
        if (hitPoint <= 0) gameObject.SetActive(false);
    }
}
