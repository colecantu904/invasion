using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    [SerializeField] public int health = 5;
    [SerializeField] public float delay = 1f;
    [SerializeField] float range = 1;
    [SerializeField] public Transform raycastStart;

    public void takeDamage()
    {
        setTargettoPlayer();
        sr.color = Color.red;
        health -= 1;
        if (health <= 0) Destroy(gameObject);
        StartCoroutine(flash());
    }

    private IEnumerator flash()
    {
        yield return new WaitForSeconds(delay);
        sr.color = Color.white;
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "patrolTarget")
        {
            collision.GetComponent<patrolTargetScript>().rotateTarget();
        }
    }

    void setTargettoPlayer()
    {
        var enemy = GetComponent<enemyMove>();
        enemy.target = GameObject.Find("Player").GetComponent<Transform>();
        GetComponent<enemyMove>().pathRate = .5f;
    }
    private void detectPlayer()
    {
        var hit = Physics2D.Raycast(raycastStart.position, raycastStart.up*range);
        
        if (hit.collider != null && !hit.collider.isTrigger&&hit.collider.tag=="Player")
        {

            setTargettoPlayer();
            Debug.Log("found");
        }
    }
    private void Update()
    {
        detectPlayer();
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(raycastStart.position, raycastStart.up*range,Color.black);
    }
}
