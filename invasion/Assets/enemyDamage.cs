using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    [SerializeField] public int dam = 1;
    [SerializeField] public float pace = 1;
    [SerializeField] public float attackRadius = 5f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<playerHealth>();
        player?.hit(dam, 0.1f);
        StartCoroutine(hurt());
    }

    private IEnumerator hurt()
    {
        yield return new WaitForSeconds(pace);
        Collider2D[] hitplayer = Physics2D.OverlapCircleAll(transform.position, attackRadius);
        foreach (Collider2D player in hitplayer)
        {
            var hitted = player.GetComponent<playerHealth>();
            hitted?.hit(dam, pace);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
