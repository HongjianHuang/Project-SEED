using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject map;

    private GameObject enemy; 
    public int enemyNumber = 6;
    void Start()
    {
        enemy = Resources.Load("Prefab/Enemy/Enemy", typeof(GameObject)) as GameObject;
        EnemySumm(enemyNumber);

        
        
    }
    public void EnemySumm(int number)
    {
        for (int i = 0; i < number;i++)
        {
            
            float randomY = Random.Range(map.GetComponent<BoxCollider2D>().bounds.max.y,map.GetComponent<BoxCollider2D>().bounds.min.y);
            float randomX = Random.Range(map.GetComponent<BoxCollider2D>().bounds.max.x,map.GetComponent<BoxCollider2D>().bounds.min.x);
            Vector2 randomPosition = new Vector2(randomX, randomY);
            Instantiate(enemy, randomPosition, transform.rotation);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            EnemySumm(1);
        }
    }
}
