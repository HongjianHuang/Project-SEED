using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector2 aimingPosition; 
    public EnemyAI enemyAI;
    public EnemyTag enemyTag;
    public Transform enemyFoot;
    public GameObject enemy;
    public LayerMask playerLayer;
    public float hammerAttRange = 1.5f;
    private Transform hammerAttPoint;
    private Transform knifeAttPoint;
    private SpriteRenderer rend;
    private float alpha; 

    private void OnEnable() 
    {   
        enemy =  gameObject.transform.parent.gameObject.transform.parent.gameObject;
        enemyAI = enemy.GetComponent<EnemyAI>();
        enemyTag = enemy.GetComponent<EnemyTag>();
        enemyFoot = enemy.transform.Find("EnemyFoot");
        if (gameObject.transform.Find("HammerAttPoint"))
            hammerAttPoint = gameObject.transform.Find("HammerAttPoint");
        if(gameObject.transform.Find("KnifeAttPoint"))
            knifeAttPoint = gameObject.transform.Find("KnifeAttPoint");
        rend = GetComponent<SpriteRenderer>();
        alpha = rend.color.a;
        player = GameObject.Find("Player");
        
            
    }
    void Start()
    {
       
        
        
        Attack();
        //enabled = false;
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
            
            //check if enemy hits the play
            StartCoroutine(AttackAction(2f, hammerAttRange));
            enabled = false;
            // 
            
            
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
    private IEnumerator AttackAction(float timer, float attackRange)
    {
        //holder for anmitation
        yield return new WaitForSeconds(timer);
        Collider2D hitPlayer = Physics2D.OverlapCircle(hammerAttPoint.position, attackRange, playerLayer);
        if (hitPlayer)
        {
            //if hits, reduce player's hp
            Debug.Log("hit player!");
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
    void OnDrawGizmosSelected()
    {
        if (hammerAttPoint == null)
            return;
        Gizmos.DrawWireSphere(hammerAttPoint.position,hammerAttRange);
    }
}
