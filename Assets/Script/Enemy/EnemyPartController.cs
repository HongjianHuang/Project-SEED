using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartController : MonoBehaviour
{
    // Start is called before the first frame update
    private int hitPoint;
    private SpriteRenderer rend;
    private Color originalColor;
    private string fileName;

    private GameObject enemyPartsBroken;
    void Start()
    {
        hitPoint = 2;
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
        fileName = gameObject.name.Remove(11) + "Broken";
        enemyPartsBroken = Resources.Load("Prefab/Enemy/" + fileName, typeof(GameObject)) as GameObject;
        //parent = transform.parent;
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        rend.color = originalColor;
    }
    void Update()
    {
        if (hitPoint <= 0)
        {
            //instantiate broken parts and destroy game object
            //enemyPartsBroken.transform.localScale = new Vector3(0.5f, 0.5f, 0);
            Instantiate(enemyPartsBroken, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "PlayerAttBox" )
        {
            rend.color = new Color(0,0,0,1);
            hitPoint -= 1;
            Debug.Log("hit!");
                       
        }
    }
}
