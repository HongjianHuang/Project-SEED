using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour


{
    public Rigidbody2D playerRB; 
    public GameObject playerBody;

    public LayerMask enemyLayers;
    public float attackRange = 0.5f;
    public Transform attackPoint;
    private Animator animator;

    //public GameObject playerBox;
    [Header("State")]
    [SerializeField] private bool onGround;
    [SerializeField] private bool isRolling = false;
    //[SerializeField] private bool atTop = false;
    [SerializeField] private float faceRight;
    [SerializeField] private float isAttacking;


    
    private Controls controls;
    [Header("Config")]
    [SerializeField] private float Y_modifier = 0.67f;
    [SerializeField] private float speed;
    [SerializeField] private float gravity;

    [SerializeField] private float terminalVelocity = -1.1f;
    [SerializeField] private float speedModifier;

    
    private Vector2 moveInput;
    private float jumpDir;




    //private BoxCollider2D playerB;

    


    private void Start()
    {
        faceRight = 1;
        onGround = true;
        animator = playerBody.GetComponent<Animator>();
    }

    private void Awake()
    {
        controls = new Controls();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Jump.performed += ctx => Jump(ctx.ReadValue<float>());
        controls.Player.Roll.performed += ctx => Roll();
        controls.Player.Att.performed += ctx => Att(ctx.ReadValue<float>());
        //playerB = playerBox.GetComponent<BoxCollider2D>();


    }

    private void OnEnable() => controls.Enable();
    private void Ondisable() => controls.Disable();

    private void Jump(float dirction)
    {
        if (isRolling || !onGround) return;
        Debug.Log("player is jumping." + dirction);
        jumpDir = dirction*speedModifier;
        

    }
    private void Att(float value)
    {
        
        isAttacking = value;

    }
    private void Rotation()
    {
        if (faceRight == 1)
        {
            transform.rotation = Quaternion.identity;
        }
        if (faceRight != 1)
        {
            transform.rotation = new Quaternion(0,-180,0,1);
        }
    }
    private void Roll()
    {
        if (isRolling || !onGround) return;
       

    }
    private void Move(Vector2 dirction)
    {
        //if (isRolling || !onGround){return;}

        
        moveInput = dirction;
    }
    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            
            if (enemy.GetComponent<EnemyController>() != null)
            {
                enemy.GetComponent<EnemyController>().TakeDamage();
            }
            if (enemy.GetComponent<EnemyPartController>() != null)
            {
                enemy.GetComponent<EnemyPartController>().TakeDamage();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void FixedUpdate()
    {

        Vector2 moveDir = new Vector2(moveInput.x*speed, moveInput.y*speed*Y_modifier);
       
        if (Input.GetKey(KeyCode.LeftArrow)) faceRight = -1;
        if (Input.GetKey(KeyCode.RightArrow)) faceRight = 1;
        Rotation();
        if (jumpDir >= terminalVelocity || playerBody.transform.localPosition.y > 1)
        {
            onGround = false;
            jumpDir -= gravity;
            if(isAttacking == 1)
            {
                animator.SetTrigger("playerChop");
                //playerAttBox.gameObject.SetActive(true);
                Attack();
            }
            playerBody.transform.localPosition = playerBody.transform.localPosition + new Vector3 (0,jumpDir*Time.deltaTime,0);
        }

        if (playerBody.transform.localPosition.y <= 1)
        {   
            /*
            if(!onGround)
            {
                moveInput = new Vector2(0.0f, 0.0f);
            }*/
            if(isAttacking == 1)
            { 
                moveDir = new Vector2(0,0);
                animator.SetTrigger("playerChop");
                //playerAttBox.gameObject.SetActive(true);
                Attack();
            }
            onGround = true;
            playerBody.transform.localPosition = new Vector3 (0,20f*Time.deltaTime,0);
            playerRB.velocity = moveDir;
        }
        
      
        
         /*
        if (playerBody.transform.localPosition.y > 1)
        {
            Debug.Log("2");
            onGround = false;
            jumpDir = -gravity;
            playerBody.transform.localPosition = playerBody.transform.localPosition + new Vector3 (0,jumpDir,0);
        }
       
        if (jumpDir == 1){
            Debug.Log("3");
            playerBody.transform.localPosition = playerBody.transform.localPosition + new Vector3 (0,jumpDir*Time.deltaTime,0);
        }
        */
    }

}
