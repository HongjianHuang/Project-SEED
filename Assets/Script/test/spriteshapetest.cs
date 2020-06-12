using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class spriteshapetest : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteShapeController prefab;
    public SpriteShapeController prefabTop;
    public GameObject spriteshape;
    public GameObject spriteshapeTop;
    private Vector3 p;
    private Vector3 p1;
    private Vector3 pt;
    private Vector3 pt1;
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    void Start()
    {
        prefabTop = spriteshapeTop.GetComponent<SpriteShapeController>();
        prefab = spriteshape.GetComponent<SpriteShapeController>();
        int points = prefab.spline.GetPointCount();
        for (int i = 0; i < points; i++)
        {
            Debug.Log(prefab.spline.GetPosition(i));
        }
        minX = prefab.spline.GetPosition(2).x;
        maxX = prefab.spline.GetPosition(0).x;
        Debug.Log(minX);
        Debug.Log(maxX);


        
    }

    // Update is called once per frame
    void Update()
    {
        p = prefab.spline.GetPosition(0);
        p1 = prefab.spline.GetPosition(1);
        pt= prefabTop.spline.GetPosition(1);
        pt1 = prefabTop.spline.GetPosition(2);
        /*
        if (p.x >= minX)
        {
            Debug.Log(p.x);
            prefab.spline.SetPosition(0, new Vector3(p.x - Time.deltaTime,p.y,p.z));
            prefab.spline.SetPosition(1, new Vector3(p1.x - Time.deltaTime,p1.y,p1.z));
        }*/
        if(p.x <= minX)
        {
            prefab.spline.SetPosition(0, new Vector3(p.x + Time.deltaTime,p.y,p.z));
            prefab.spline.SetPosition(1, new Vector3(p1.x + Time.deltaTime,p1.y,p1.z));
            prefabTop.spline.SetPosition(1, new Vector3(pt.x + Time.deltaTime, pt.y, pt.z));
            prefabTop.spline.SetPosition(2, new Vector3(pt1.x + Time.deltaTime, pt1.y, pt1.z));
        }

        
    }
}
