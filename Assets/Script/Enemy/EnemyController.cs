using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public int partsNum;
    public int hitPoint; 
    private SpriteRenderer rend;
    private Color originalColor;
    private GameObject enemyBody;

    public bool bodyExposed;




    private void Start()
    {
        enemyBody = GameObject.Find("EnemyBody");
        rend = enemyBody.GetComponent<SpriteRenderer>();
        originalColor = rend.color;
        hitPoint = 2;
        partsNum = Random.Range(0,7);
        bodyExposed = true;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (hitPoint <= 0) gameObject.SetActive(false);
    }
    public void TakeDamage()
    {
        if(bodyExposed)
        {
            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.75f);
            FindObjectOfType<HitStop>().Stop(0.1f);
            StartCoroutine(WaitForDamage());
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "PlayerAttBox" )
        {
            if (bodyExposed)
            {
                rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.75f);
                FindObjectOfType<HitStop>().Stop(0.1f);
                StartCoroutine(WaitForDamage());
            }
            
        }
    }
    IEnumerator WaitForDamage()
    {
        while(Time.timeScale != 1.0f) yield return null; 
        rend.color = originalColor;
        hitPoint -= 1;
    }
}
