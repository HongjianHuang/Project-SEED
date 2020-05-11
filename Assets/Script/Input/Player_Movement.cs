using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Movement : MonoBehaviour


{
    private bool on_ground = true;
    private bool is_rolling = false;

    private Controls controls;
    
    public Rigidbody2D playerRB; 
    public float y_modifier;
    float y_moveDir;
    float x_moveDir;
    public float speed;

    private void Awake()
    {
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
        y_moveDir = dirction * y_modifier;

    }
    private void Update()
    {

        
        Vector2 moveDir = new Vector2(x_moveDir*speed, y_moveDir*speed);
        playerRB.velocity = moveDir;
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);
    }

}
