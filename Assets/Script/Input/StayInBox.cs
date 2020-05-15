using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInBox : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject playerMovement;
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("at top");
    }
}
