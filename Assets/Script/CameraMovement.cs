using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Reference")]
    [SerializeField]private Transform target;
    

    [Header("Tweaks")]
    [SerializeField]private Vector3 offset = new Vector3(0,10,-10);

    [Header ("Bounds")]
    [SerializeField] private bool enableBounds = true;
    [SerializeField] private float bounds = 3f;

    [Header("Smooth")]
    [SerializeField] private bool enableSmooth = true; 
    [SerializeField] private float smoothSpeed = 0.125f;
    private Vector3 desiredPosition;
    void FixedUpdate()
    {
        desiredPosition = target.position + offset;

        //If we have bounds, change the X value to relect our logic
        if (enableBounds)
        {
            //Let's check if we're inside the bounds
            float deltaX = target.position.x - transform.position.x;
            if (Mathf.Abs(deltaX) > bounds)
            {
                if (deltaX > 0)
                {
                    desiredPosition.x = target.position.x - bounds;
                }
                else
                {
                    desiredPosition.x = target.position.x + bounds;
                }
            }
            else
            {
                desiredPosition.x = target.position.x - deltaX;
            }
        }
        if (enableSmooth)
        {
            transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
        }
        else
        {
            transform.position = desiredPosition;
        }
        
    }
}
