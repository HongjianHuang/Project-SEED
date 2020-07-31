using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector2 aimingPosition; 
    public EnemyAI enemyAI;
    public EnemyTag enemyTag;
    public Transform enemyFoot;
    public GameObject enemy;
    public LayerMask playerLayer;
    
    private Transform hammerAttPoint;
    private Transform knifeAttPoint;


    private void OnEnable() 
    {   
        enemyAI = gameObject.GetComponent<EnemyAI>();
        enemyTag = gameObject.GetComponent<EnemyTag>();
        enemy =  gameObject.transform.parent.gameObject.transform.parent.gameObject;
        enemyFoot = enemy.transform.Find("EnemyFoot");
        if (gameObject.transform.Find("HammerAttPoint"))
            hammerAttPoint = gameObject.transform.Find("HammerAttPoint");
        if(gameObject.transform.Find("KnifeAttPoint"))
            knifeAttPoint = gameObject.transform.Find("KnifeAttPoint");
        
        
            
    }
    void Start()
    {
        
        //when this script starts, all disable all other scripts.
        //calling Attack
        

    }
    
    private void Attack()
    {
        if(enemyAI.attackMode == attackModeManager.gun)
        {
            // play gun back swing animation 
            // aim process
            // aim at the player 
            //target = player;
            
            return;
        }
        else if (enemyAI.attackMode == attackModeManager.hammer)
        {
            //play hammer backswing animation
            //attack animation
            int attackRange = 3;
            //check if enemy hits the play
            Collider2D hitPlayer = Physics2D.OverlapCircle(hammerAttPoint.position, attackRange, playerLayer);
            if (hitPlayer)
            {
                //if hits, reduce player's hp
                Debug.Log("hit player!");
            }
            
            
            //afterswing timer   
            return;
        }
        else if (enemyAI.attackMode == attackModeManager.knife)
        {
            //animation time is much shorter than other
            //play hammer backswing animation
            //attack animation
            //check if enemy hits the play
            //if hits, reduce player's hp
            //afterswing timer
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
