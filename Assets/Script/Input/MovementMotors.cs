using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMotors : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Logic")]
    [SerializeField] private Animator animator;
    private CharacterController controller;
    private Vector3 slopeNormal;
    [SerializeField] private bool grounded;
    private float verticalVelocity;

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
    }
    private Vector3 PoolInput()
    {
        Vector3 r =  default(Vector3);

        r.x = Input.GetAxisRaw("Horizontal");
        r.y = Input.GetAxisRaw("Vertical");

        return r.normalized;

    }
    public bool Grounded()
    {
        if(verticalVelocity > 0)
        {
            return true;
        }
        float yRay = (controller.bounds.center.y - (controller.height * 0.5f))
                    + innerVerticalOffset; // Bottom of the character controller
        RaycastHit hit;
        // Mid
        if (Physics.Raycast(new Vector3(controller.bounds.center.x, yRay, controller.bounds.center.z),
                            -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            Debug.DrawRay(new Vector3(controller.bounds.center.x, yRay, controller.bounds.center.z), 
                -Vector3.up * (innerVerticalOffset + distanceGrounded), Color.red);

            slopeNormal = hit.normal;
            return true;
        }
        // Front Right
        if (Physics.Raycast(new Vector3(controller.bounds.center.x + (controller.bounds.extents.x - extremitiesOffset),
                            yRay, controller.bounds.center.z + (controller.bounds.extents.z -extremitiesOffset)),
                            -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return true;
        }
        // Front Left
        if (Physics.Raycast(new Vector3(controller.bounds.center.x - (controller.bounds.extents.x - extremitiesOffset),
                            yRay, controller.bounds.center.z + (controller.bounds.extents.z -extremitiesOffset)),
                            -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return true;
        }
        // Back Right
        if (Physics.Raycast(new Vector3(controller.bounds.center.x + (controller.bounds.extents.x - extremitiesOffset),
                            yRay, controller.bounds.center.z - (controller.bounds.extents.z -extremitiesOffset)),
                            -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return true;
        }
        // Back Left
        if (Physics.Raycast(new Vector3(controller.bounds.center.x - (controller.bounds.extents.x - extremitiesOffset),
                            yRay, controller.bounds.center.z - (controller.bounds.extents.z -extremitiesOffset)),
                            -Vector3.up, out hit, innerVerticalOffset + distanceGrounded))
        {
            slopeNormal = hit.normal;
            return true;
        }

        return true;
        
    
    }
    private void FixedUpdate()
    {
        // Look at which key the user is pressing, store it
        Vector3 inputVector = PoolInput();
        // Multiply the inputs with the speed, and switch Y & Z
        Vector3 moveVector = new Vector3(inputVector.x * speedX, 0, inputVector.y * speedY);
        controller.Move(moveVector * Time.deltaTime);
        // Store it in a varriable, so we don't call it more than once per frame
        grounded = Grounded();
        if (grounded)
        {
            // Apply slight gravity
            verticalVelocity = -1;

            // If spacebar, apply high negative gravity, and forget about the floor
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
                slopeNormal = Vector3.up; 
                Debug.Log("space!");
            }

        }
        else
        {
            verticalVelocity -= gravity;
            slopeNormal = Vector3.up;

            // Clamp to match terminal velocity, if faster
            if (verticalVelocity < -terminalVelocity)
                verticalVelocity = -terminalVelocity;
        }
        // Apply vericalVelocity to our movment vector
        moveVector.y = verticalVelocity;

        //move the controller, checks for collisions
        controller.Move(moveVector * Time.deltaTime);

    }

    


    // Update is called once per frame
}
