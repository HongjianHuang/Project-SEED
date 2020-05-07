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
        y_moveDir = dirction * 0.6f;

    }
    private void FixedUpdate()
    {
        Vector2 moveDir = new Vector2(x_moveDir*speed*Time.fixedDeltaTime, y_moveDir*speed*Time.fixedDeltaTime);
        playerRB.velocity = moveDir;
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, speed * Time.deltaTime);
        if (raycastHit.collider == null)
        {
            //Can move, no hit
            playerRB.velocity = moveDir;
        }
        else
        {
            //cannot move hit something
            Vector3 testMoveDir = new Vector3(moveDir.x, 0f).normalized;
            raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed*Time.deltaTime);
            if (raycastHit.collider == null)
            {
                // can move horizontally
                moveDir = testMoveDir;
                playerRB.velocity = moveDir;

            }
            else
            {
                //cannot move horizontally
                testMoveDir = new Vector3 (0f, moveDir.y).normalized;
                raycastHit = Physics2D.Raycast(transform.position, testMoveDir, speed * Time.deltaTime);
                if(raycastHit.collider == null){
                    // Canmove Vertically
                    
                }
                else
                {

                }
            }


        }
    }

}
