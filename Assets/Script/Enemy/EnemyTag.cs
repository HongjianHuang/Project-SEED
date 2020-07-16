using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTag : MonoBehaviour
{
    // Start is called before the first frame update
    public bool gun, knife, hammer, hexapod, track;
    public Transform enemyBody; 
    void Start()
    {
        gun = true; 
        knife = true;
        hammer = true; 
        hexapod = true; 
        track = true; 
        enemyBody = gameObject.transform.Find("EnemyBody");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (enemyBody.transform.Find("EnemyParts0(Clone)") == null)
        {
            gun = false;
        }
        if (enemyBody.transform.Find("EnemyParts1(Clone)") == null)
        {
            knife = false;
        }
        if (enemyBody.transform.Find("EnemyParts2(Clone)") == null)
        {
            hammer = false;
        }
        if (enemyBody.transform.Find("EnemyParts3(Clone)") == null)
        {
            hexapod = false;
        }
        if (enemyBody.transform.Find("EnemyParts4(Clone)") == null)
        {
            track = false;
        }
     
    }
}
