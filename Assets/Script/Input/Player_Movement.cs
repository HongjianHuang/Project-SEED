using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Movement : MonoBehaviour


{
    private bool on_ground = true;
    private bool is_rolling = false;
    private CharacterController controller;
    private Vector3 slopeNormal;
    private Controls controls;
<<<<<<< HEAD
    public Rigidbody playerRB; 
    public float y_modifier;
=======
    
    public Rigidbody2D playerRB; 
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> parent of 9053811... MainMenu fix
=======
>>>>>>> parent of 9053811... MainMenu fix
=======
>>>>>>> parent of 9053811... MainMenu fix
    float y_moveDir;
    float x_moveDir;
    public float speed;
    [Header("Movement config")]
    [SerializeField] private float speedX = 5;
    [SerializeField] private float speedY = 5;
    [SerializeField] private float gravity = 0.25f;
    [SerializeField] private float jumpForce = 8.0f;
    [SerializeField] private float terminalVelocity = 5.0f;
    
    [Header("Ground Check Raycast")]
    [SerializeField] private float extremitiesOffset = 0.05f;
    [SerializeField] private float innerVerticalOffset = 0.25f;
    [SerializeField] private float distanceGrounded = 0.15f;
    [SerializeField] private float slopeThreshold = 0.55f;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        controls = new Controls();
        controls.Player.MoveRightLeft.performed += ctx => MoveRightLeft(ctx.ReadValue<float>());
        controls.Player.MoveUpDown.performed += ctx => MoveUpDown(ctx.ReadValue<float>());
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.Roll.performed += ctx => Roll();


    }

    private void OnEnable() => controls.Enable();
    private void Ondisable() => controls.Disable();
    
    private void Jump()
    {
        if (is_rolling || !on_ground) {return;}
        Debug.Log("player is jumping.");

    }
    
    private void Roll()
    {
        if (is_rolling || !on_ground) {return;}
        Debug.Log("player is rolling.");

    }
    private void MoveRightLeft(float dirction)
    {
        if (is_rolling || !on_ground){return;}

        Debug.Log("Player wants to move:" + dirction);
        x_moveDir = dirction;

    }
    private void MoveUpDown(float dirction)
    {
        if (is_rolling || !on_ground){return;}

        Debug.Log("Player wants to move:" + dirction);
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        y_moveDir = dirction;

    }

    private Vector3 PoolInput()
    {
        Vector3 r =  default(Vector3);

        r.x = x_moveDir;
        r.y = y_moveDir;

        return r.normalized;
=======
        y_moveDir = dirction * 0.6f;
>>>>>>> parent of 9053811... MainMenu fix
=======
        y_moveDir = dirction * 0.6f;
>>>>>>> parent of 9053811... MainMenu fix
=======
        y_moveDir = dirction * 0.6f;
>>>>>>> parent of 9053811... MainMenu fix

    }
    private void Update()
    {

        Vector3 inputVector = PoolInput();
        Vector3 moveDir = new Vector3(inputVector.x * speedX,0, inputVector.y*speedY);
        playerRB.velocity = moveDir;
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);
    }

}
