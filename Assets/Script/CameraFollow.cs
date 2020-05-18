using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private  BoxCollider2D cameraBounds;
    [Header("Objects")]
    public Transform target;
    public float smoothSpeed = 0.125f;
    public GameObject map;
    public Camera mainCamera;

    [Header("Config")]
    [SerializeField] private  Vector3 offset;

    [Header("Status")]
    [SerializeField] private Vector3 max;
    [SerializeField] private Vector3 min;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private float cameraHalfWidth;


    private void Start()
    {
        cameraBounds = map.GetComponent<BoxCollider2D>();
        max = cameraBounds.bounds.max;
        min = cameraBounds.bounds.min;
        cameraHalfWidth = mainCamera.orthographicSize * ((float)Screen.width / Screen.height);
        //Debug.Log("max is " + max);
        //Debug.Log("min is " + min);
        
    }

    private void FixedUpdate()
    {
        
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPostion = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed);
        x = Mathf.Clamp(smoothedPostion.x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
        y = Mathf.Clamp(smoothedPostion.y, min.y 
                    + mainCamera.orthographicSize, Mathf.Infinity);
        
        Vector3 boundPosition = new Vector3 (x, y, transform.position.z);
        transform.position = boundPosition;
     
        
    }
}
