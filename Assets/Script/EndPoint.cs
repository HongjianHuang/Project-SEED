using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.name == "End Point Collider")
        {
            Debug.Log("You win!");
        }
    }
}
