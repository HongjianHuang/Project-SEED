using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector2 aimingPosition; 
    public int attackRange;
    public EnemyAI enemyAI;
    public EnemyTag enemyTag;


    private void OnEnable() 
    {
        enemyAI = gameObject.GetComponent<EnemyAI>();
        enemyTag = gameObject.GetComponent<EnemyTag>();
       
    }
    void Start()
    {
        

    }
    
    private void Backswing()
    {
        if(enemyAI.attackMode == attackModeManager.gun)
        {
            // play gun back swing animation 
            // aim process
            // aim at the player 
            return;
        }
        else if (enemyAI.attackMode == attackModeManager.hammer)
        {
            //play hammer backswing animation   
            return;
        }
        else if (enemyAI.attackMode == attackModeManager.knife)
        {
            //play knife backswing animation
            return;
        }
        else
        {
            //no weapon
            //play normal backswing animation
            return;
        }
    }
    private void Shoot()
    {
        //cast a ray to the position where it was aiming at. 
        //if hits, player takes damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
