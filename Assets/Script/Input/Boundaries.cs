using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Floor;
    private BoxCollider2D floorCollider;
    private Vector2 floorBounds;
    void Start()
    {
        floorCollider = Floor.GetComponent<BoxCollider2D>();
        floorBounds = floorCollider.bounds.size;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 floorPos = transform.position;
        floorPos.x = Mathf.Clamp(floorPos.x, floorBounds.x, floorBounds.x * -1);
        floorPos.y = Mathf.Clamp(floorPos.y, floorBounds.y, floorBounds.y * -1);
        transform.position = floorPos;
    }
}
