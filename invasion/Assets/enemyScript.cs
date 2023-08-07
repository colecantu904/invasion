using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] public int health = 5;
    public void takeDamage()
    {
        sr.color = Color.red;
        health -= 1;
        if (health <= 0) Destroy(gameObject);
        Debug.Log("ouch");
    }
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
    }
}
