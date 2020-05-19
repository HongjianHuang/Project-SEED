using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Movement : MonoBehaviour


{
    public Rigidbody2D playerRB; 
    public GameObject playerBody;
    //public GameObject playerBox;
    [Header("State")]
    [SerializeField] private bool onGround;
    [SerializeField] private bool isRolling = false;
    //[SerializeField] private bool atTop = false;
    [SerializeField] private bool faceRight;


    
    private Controls controls;
    [Header("Config")]
    [SerializeField] private float Y_modifier = 0.67f;
    [SerializeField] private float speed = 200000000;
    [SerializeField] private float gravity = 0;

    [SerializeField] private float terminalVelocity = -1.1f;

    
    private Vector2 moveInput;
    private float jumpDir;


    //private BoxCollider2D playerB;

    


    private void Start()
    {
        faceRight = true;
        onGround = true;
    }

    private void Awake()
    {
        controls = new Controls();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        controls.Player.Jump.performed += ctx => Jump(ctx.ReadValue<float>());
        controls.Player.Roll.performed += ctx => Roll();
        //playerB = playerBox.GetComponent<BoxCollider2D>();


    }

    private void OnEnable() => controls.Enable();
    private void Ondisable() => controls.Disable();

    private void Jump(float dirction)
    {
        if (isRolling || !onGround) {return;}
        Debug.Log("player is jumping." + dirction);
        jumpDir = dirction;
        

    }
    private void Rotation()
    {
        if (faceRight)
        {
            playerBody.transform.localRotation = Quaternion.identity;
        }
        if (!faceRight)
        {
            playerBody.transform.localRotation = new Quaternion(0,-180,0,1);
        }
    }
    private void Roll()
    {
        if (isRolling || !onGround) {return;}
        Debug.Log("player is rolling.");

    }
    private void Move(Vector2 dirction)
    {
        //if (isRolling || !onGround){return;}

        Debug.Log("Player wants to move:" + dirction);
        moveInput = dirction;
    }
    private void FixedUpdate()
    {

        Vector2 moveDir = new Vector2(moveInput.x*speed, moveInput.y*speed*Y_modifier);
        if (Input.GetKey(KeyCode.LeftArrow)){ faceRight = false;}
        if (Input.GetKey(KeyCode.RightArrow)){ faceRight = true;}
        Rotation();
        if (jumpDir >= terminalVelocity || playerBody.transform.localPosition.y > 1)
        {
            onGround = false;
            jumpDir -= gravity;
            playerBody.transform.localPosition = playerBody.transform.localPosition + new Vector3 (0,jumpDir,0);
        }

        if (playerBody.transform.localPosition.y <= 1)
        {   
            /*
            if(!onGround)
            {
                moveInput = new Vector2(0.0f, 0.0f);
            }*/
            onGround = true;
            playerBody.transform.localPosition = new Vector3 (0,1,0);
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
