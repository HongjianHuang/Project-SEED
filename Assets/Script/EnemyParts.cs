using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParts : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector2 center;
    private Vector2 size;
    private Vector2 min;
    private Vector2 max;
    
    private Collider2D col;
    private Dictionary<string, Vector2> points = new Dictionary<string, Vector2>();

    private void Awake()
    {
        
    }
    void Start()
    {
        
        col = gameObject.GetComponent<Collider2D>();
        center = col.bounds.center;
        size = col.bounds.size;
        min = col.bounds.min;
        max = col.bounds.max;
        calculatePoint();
        
    }
    private void OnDrawGizmos()
    {
        foreach (KeyValuePair<string, Vector2> entry in points)
        {
            Debug.Log(entry);
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + 
                new Vector3(entry.Value.x, entry.Value.y, 0), 0.5f);
            
        }
    }
    private void calculatePoint()
    {
        Vector2 upMid = new Vector2 (0, (max.y - center.y)/2);
        Vector2 downMid = new Vector2(0, (min.y - center.y)/2); 
        points.Add("midRight", new Vector2((max.x - center.x)/2, 0));
        points.Add("midLeft", new Vector2((min.x - center.x)/2, 0));
        points.Add("upMid", upMid);
        points.Add("downMid",downMid);
        points.Add("head",new Vector2 (0, upMid.y + upMid.y/2));
        points.Add("foot",new Vector2 (0, downMid.y + downMid.y/2));  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
