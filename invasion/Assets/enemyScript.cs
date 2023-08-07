using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    [SerializeField] public int health = 5;
    [SerializeField] public float delay = 1f;
    private bool activated = false;

    public void takeDamage()
    {

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
        if (collision.tag == "Player" && !activated)
        {
            var enemy = GetComponent<enemyMove>();
            enemy.enabled = true;
            enemy.target = collision.transform;
        }
    }
}
