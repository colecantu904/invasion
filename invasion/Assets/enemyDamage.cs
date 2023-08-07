using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    [SerializeField] public int dam = 1;
    [SerializeField] public float pace = 1;
    private bool hitted = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player"&&!hitted)
        {
            var player = collision.GetComponent<playerHealth>();
            player?.hit(dam);
            hitted = true;
            StartCoroutine(unhit());
        }
    }


    private IEnumerator unhit()
    {
        yield return new WaitForSeconds(pace);
        hitted = false;
     }


 }


