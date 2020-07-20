using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPartController : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoint;
    public SpriteRenderer rend;
    public Color originalColor;
    private string fileName;
    private Shader hitShader;

    private GameObject enemyPartsBroken;
    void Start()
    {

        hitPoint = 2;
        rend = GetComponent<SpriteRenderer>();
        originalColor = rend.color;
        fileName = gameObject.name.Remove(11) + "Broken";
        enemyPartsBroken = Resources.Load("Prefab/Enemy/" + fileName, typeof(GameObject)) as GameObject;
        hitShader = Shader.Find("GUI/Text Shader");
        
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
    public void TakeDamage()
    {
        rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.75f);
        FindObjectOfType<HitStop>().Stop(0.1f);
        StartCoroutine(WaitForDamage());
    }
    /*    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "PlayerAttBox" )
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.75f);
            FindObjectOfType<HitStop>().Stop(0.1f);
            StartCoroutine(WaitForDamage());
            
            
                       
        }
    }*/
    IEnumerator WaitForDamage()
    {
        while(Time.timeScale != 1.0f) yield return null; 
        rend.color = originalColor;
        hitPoint -= 1;
    }


}
