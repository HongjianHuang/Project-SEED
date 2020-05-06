using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player_Movement : MonoBehaviour


{
    private bool on_ground = true;
    private bool is_rolling = false;

    public Transform playerPosition;
    private Controls controls;
    
    float moveDir;
    private void Awake()
    {
        controls = new Controls();
        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<float>());
       
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
        private void Move(float dirction)
    {
        if (is_rolling || !on_ground){return;}

        Debug.Log("Player wants to move:" + dirction);
        moveDir = dirction;

    }
    private void FixedUpdate()
    {
        
    }

}
