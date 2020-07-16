using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Vector2 aimingPosition; 
    public int attackRange;
    private string attackMode; 
    void Start()
    {

    }
    
    private void Loading()
    {
        //aim at the player's position
        //wait 3s before shoot
    }
    private void Shoot()
    {
        //cast a ray to the position where it was aiming at. 
        //if hits, player takes damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
