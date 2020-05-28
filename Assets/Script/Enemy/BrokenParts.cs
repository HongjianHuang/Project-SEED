using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenParts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemyFoot;

    private Vector3 footPosition;
    
    void Start()
    {
        footPosition = enemyFoot.transform.position;
        Debug.Log(footPosition);
    }

    // Update is called once per frame
    void Update()
    {
        footPosition = enemyFoot.transform.position;
    }
}
