using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
    // Start is called before the first frame update
 
    

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BrokenParts")
        {
            
            Destroy(other.gameObject);
        }
    }
}
