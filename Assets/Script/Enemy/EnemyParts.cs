﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParts : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector2 center;
    private Vector2 size;
    private Vector2 min;
    private Vector2 max;
    
    private EnemyController enemyController;
    private Collider2D col;

    private Dictionary<string, Vector2> points = new Dictionary<string, Vector2>();

    private Dictionary<string, Vector2> randomPoints = new Dictionary<string, Vector2>();

    private void Awake()
    {
        
    }
    void Start()
    {
        enemyController = gameObject.GetComponentInParent<EnemyController>();
        col = gameObject.GetComponent<Collider2D>();
        center = col.bounds.center;
        size = col.bounds.size;
        min = col.bounds.min;
        max = col.bounds.max;
        calculatePoint();
        randomPoints = randomListElement();
        
        
        
        foreach (KeyValuePair<string, Vector2> entry in randomPoints)
        {
            string randomNum = Random.Range(0,5).ToString();
            GameObject enemyParts = Resources.Load("Prefab/Enemy/EnemyParts" + randomNum, typeof(GameObject)) as GameObject;
            
            if (enemyParts != null)
            {
                enemyParts.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                Instantiate(enemyParts, transform.position + 
                            new Vector3(entry.Value.x, entry.Value.y, 0), transform.rotation, transform);
               
     
            }
            
            
        }
    }
    //a list with all the possible parts that can attach to the body 
    public List<string> keyToList(Dictionary<string, Vector2> pointsDic)
    {
        List<string> keyList = new List<string>();
        foreach (KeyValuePair<string, Vector2> entry in pointsDic)
        {
            keyList.Add(entry.Key);
        }
        
        return keyList;
    }
    //create a dictionary with random selected elements from a list
    private Dictionary<string, Vector2> randomListElement()
    {
        //return a dictionary of matching keys and value
        List<string> keyList = keyToList(points);
        Dictionary<string, Vector2> result = new Dictionary<string, Vector2>();
        //Use indexList to make sure every index only appear once
        List<int> indexList = new List<int>();
        for (int i = 0; i < keyList.Count; i++)
        {
            indexList.Add(i);

        }
        //for the random number of times, add a random parts to the enemy; 
        for (int n = 0; n < enemyController.partsNum; n++)
        {
            int index = Random.Range(0, indexList.Count); 
            int randomIndex = indexList[index];
            indexList.Remove(indexList[index]);
            result.Add(keyList[randomIndex], points[keyList[randomIndex]]);
            
        }
        return result;
    }
    //Draw on the points
    /*
    private void OnDrawGizmos()
    {

        foreach (KeyValuePair<string, Vector2> entry in randomPoints)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + 
                new Vector3(entry.Value.x, entry.Value.y, 0), 0.5f);
            
        }
    }*/
    //calculate the location information for the parts to attach to
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
    //if there is no parts on the body, the core is exposed
    private bool exposedOrNot()
    {

        return transform.childCount == 0? true : false; 
    }
    // Update is called once per frame
    void Update()
    {
        enemyController.bodyExposed = exposedOrNot();
    }
}
