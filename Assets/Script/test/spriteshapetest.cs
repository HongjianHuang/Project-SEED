using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class spriteshapetest : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteShapeController prefab;
    public SpriteShapeController prefabTop;

    public SpriteShapeController prefabFront;
    public SpriteShapeController prefabOpp;
    public GameObject spriteshape;
    public GameObject spriteshapeTop;
    public GameObject spriteshapeFront; 
    public GameObject spriteshapeOpp;
    public float centerPoint; 
    public float maxDistance;  
    private Vector3 p;
    private Vector3 p1;
    private Vector3 pt;
    private Vector3 pt1;
    private Vector3 po;
    private Vector3 po1;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    public float cameraDistance;
    public float startPoint; 
    public float endPoint; 
    public float ratio; 

    

    
    void Start()
    {
        
        maxDistance = 24f;
      
        centerPoint = spriteshapeFront.transform.GetComponent<Renderer>().bounds.center.x;
        prefabTop = spriteshapeTop.GetComponent<SpriteShapeController>();
        prefab = spriteshape.GetComponent<SpriteShapeController>();
        prefabFront = spriteshapeFront.GetComponent<SpriteShapeController>();
        prefabOpp = spriteshapeOpp.GetComponent<SpriteShapeController>();
        int points = prefab.spline.GetPointCount();
        for (int i = 0; i < points; i++)
        {
            Debug.Log(prefab.spline.GetHeight(i));
        }
        
        Debug.Log(spriteshapeFront.transform.GetComponent<Renderer>().bounds.center.x);
        minX = prefab.spline.GetPosition(2).x;
        maxX = prefab.spline.GetPosition(0).x;
        startPoint = prefabTop.spline.GetPosition(2).x;
        endPoint = 1.45f;
        p = prefab.spline.GetPosition(0);
        p1 = prefab.spline.GetPosition(1);
        pt= prefabTop.spline.GetPosition(1);
        pt1 = prefabTop.spline.GetPosition(2);
        po = prefabOpp.spline.GetPosition(0);
        po1 = prefabOpp.spline.GetPosition(1);

        //Debug.Log(minX);
        //Debug.Log(maxX);


        
    }

    // Update is called once per frame
    void Update()
    {
        cameraDistance = centerPoint- transform.position.x;


        //Debug.Log(cameraDistance/maxDistance);
        ratio = (endPoint - startPoint)*(1f - cameraDistance/maxDistance);
        Debug.Log(ratio);
        /*
        if (p.x >= minX)
        {
            Debug.Log(p.x);
            prefab.spline.SetPosition(0, new Vector3(p.x - Time.deltaTime,p.y,p.z));
            prefab.spline.SetPosition(1, new Vector3(p1.x - Time.deltaTime,p1.y,p1.z));
        }*/
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + 2f*Time.deltaTime, transform.position.y, -10);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - 2f*Time.deltaTime, transform.position.y, -10);
        }
       
        if (Mathf.Abs(cameraDistance) <= maxDistance)
        {
            prefab.spline.SetPosition(0, new Vector3(p.x + ratio, p.y, p.z));
            prefab.spline.SetPosition(1, new Vector3(p1.x + ratio, p1.y, p1.z));
            prefabTop.spline.SetPosition(1, new Vector3(pt.x + ratio , pt.y, pt.z));
            prefabTop.spline.SetPosition(2, new Vector3(pt1.x + ratio, pt1.y, pt1.z));
            prefabOpp.spline.SetPosition(0, new Vector3(po.x + ratio, po.y, po.z));
            prefabOpp.spline.SetPosition(1, new Vector3(po1.x + ratio, po1.y, po1.z));

        }
        


        
    }
}
