using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastManager : MonoBehaviour
{
    
    public bool ChackRayCast(Rigidbody2D rb, int layerMask)
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, -Vector2.up, layerMask);
        return hit.collider != null; 
    }
}
