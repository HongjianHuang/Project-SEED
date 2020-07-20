using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


public enum attackModeManager
    {
        gun,
        knife,
        hammer,
        none
    };
public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeedRange = 140f;
    public float minSpeed = 70f; 
    public float speed = 0;
    public float nextWayPointDistance = 3f;
    public float triggerDistance = 10f; 
    public Vector2 direction; 
    private bool targetInRange = false; 
    public float range;
    public float attackRange;
    public float timer = 0;
    public Vector2 force; 
    public attackModeManager attackMode;
    public int partsCount;
    private Path path;
    private int currentWayPoint = 0;
    private bool reachedEndOfPath = false; 
    //private NPCController nController;
    public float totalDistance; 
    private Seeker seeker;
    private Rigidbody2D rb;
    private Vector2 roamingP;
    private WaitForSeconds waitForSeconds = new WaitForSeconds(0.1f);
    private Transform target;
    private ChasingAI cAI;
    private RomingAI rAI;
    private EnemyTag enemyTag;
    private Transform enemyBody;
    public bool ChangeState
    {
        get { return targetInRange;}
        set
        {
            if (value == targetInRange) return;
            targetInRange = value; 
            if (!targetInRange)
            {
                Debug.Log("should be false" + targetInRange);
                rAI.enabled = true;
            }
        }
    } 
    void Start()
    {
        //nController = FindObjectOfType<NPCController>();
        direction = Vector2.zero;
        cAI = GetComponent<ChasingAI>();
        rAI = GetComponent<RomingAI>();
        totalDistance = Mathf.Infinity;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        enemyTag = GetComponent<EnemyTag>();
        enemyBody = gameObject.transform.Find("EnemyBody");
         
        
    }
    void UpdatePath()
    {

        seeker.StartPath(rb.position, target.position, OnPathComplete);

    }
    public float SpeedAlter(){
    
    
        
        return maxSpeedRange;
    }

    
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    public void CheckTags()
    {
        //checks the tags of the enemy, and dejuest the attributes accordingly
        if (enemyTag == null)
        {
            Debug.Log(transform.name + " enemyTag not found");
        }
        if (enemyTag.gun) 
        {
            attackRange = 15;
        }
        else if (enemyTag.knife)
        {
            attackRange = 2;
        }
        else if (enemyTag.hammer)
        {
            attackRange = 6;
        }
    }

    // Update is called once per frame
    public void ChangeMode()
    {
        if(totalDistance >15 && enemyTag.gun) attackMode = attackModeManager.gun;
        else if (totalDistance > 2 && enemyTag.hammer)attackMode = attackModeManager.hammer;
        else if (enemyTag.knife)attackMode = attackModeManager.knife;
        else attackMode = attackModeManager.none; 
    }
    void LateUpdate()
    {
        CheckTags();
        ChangeMode();
        if (totalDistance < range)
        {
            timer = 5f;
            ChangeState = true;
        }
        if (ChangeState) timer -= Time.deltaTime;
        if (timer <= 0) 
        {
            cAI.enabled = false;
            ChangeState = false;
        }
        
    }
   
    private void FixedUpdate()
    {
        
        
        if (path == null) return; 
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return; 
        }
        else
        {
            reachedEndOfPath = false;
        }
        //Move
        //FindObjectOfType<NPCController>().FollowTarget(path, rb, speed, nextWayPointDistance, currentWayPoint);
        //turn face;
        //set trigger distance
        direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        speed = minSpeed + SpeedAlter();
        force = direction * speed * Time.deltaTime;
        
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        totalDistance = Vector2.Distance(rb.position, path.vectorPath[path.vectorPath.Count - 1]);
        
        if (ChangeState == true)
        {
            rAI.enabled = false;
            cAI.enabled = true;   
        }

        if (distance < nextWayPointDistance)
        {
            currentWayPoint++;
        }
        
            

    }
}
