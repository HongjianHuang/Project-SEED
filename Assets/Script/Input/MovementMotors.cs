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
    private bool grounded;
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
    private void FixedUpdate()
    {
        Vector3 inputVector = PoolInput();

        Vector3 moveVector = new Vector3(inputVector.x * speedX, 0, inputVector.y * speedY);
        controller.Move(moveVector * Time.deltaTime);
    }

    


    // Update is called once per frame
}
