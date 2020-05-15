using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Movement : MonoBehaviour


{
    public Rigidbody2D playerRB; 
    public GameObject playerBody;
    public GameObject playerBox;
    [Header("State")]
    [SerializeField] private bool onGround = true;
    [SerializeField] private bool isRolling = false;
    [SerializeField] private bool atTop = false;
    [SerializeField] private int faceDir;

    
    private Controls controls;
    [Header("Config")]
    [SerializeField] private float Y_modifier = 0.67f;
    [SerializeField] private float speed = 20;
    [SerializeField] private float gravity = 1;
    
    private Vector2 moveInput;
    private float jumpDir;

    //private BoxCollider2D playerB;

    


    

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
    
    private void Roll()
    {
        if (isRolling || !onGround) {return;}
        Debug.Log("player is rolling.");

    }
    private void Move(Vector2 dirction)
    {
        if (isRolling || !onGround){return;}

        Debug.Log("Player wants to move:" + dirction);
        Debug.Log(playerBody.transform.localPosition);
        moveInput = dirction;
    }

    private void FixedUpdate()
    {

        Vector2 moveDir = new Vector2(moveInput.x*speed, moveInput.y*speed*Y_modifier);
        playerRB.velocity = moveDir;
        playerBody.transform.localPosition = playerBody.transform.localPosition + new Vector3 (0,jumpDir,0);
        if (playerBody.transform.localPosition.y > 1.1){
            onGround = false;
        }
    }

}
